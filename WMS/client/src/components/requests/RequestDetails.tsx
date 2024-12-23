import {
  Divider,
  Grid2 as Grid,
  Typography,
  Paper,
  Stack,
  FormControl,
  FormLabel,
  RadioGroup,
  FormControlLabel,
  Radio,
  Tooltip,
  Button,
} from '@mui/material';
import { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { styled } from '@mui/material/styles';
import { PageContainer } from '@toolpad/core';
import { PageToolbar } from '../toolbar/PageToolbar';
//import { toast } from 'react-toastify';

import { useAppDispatch, useAppSelector } from '../../store/hooks';
import {
  addApprovalStatus,
  fetchRequestAsync,
  requestSelectors,
  setRequestType,
} from '../../pages/request/requestSlice';

import LoadingComponent from '../loading/LoadingComponent';
//import agent from '../../api/agent';
//import { useForm } from 'react-hook-form';

interface RequestDetailsFormFields extends HTMLFormControlsCollection {
  requestTitle: HTMLInputElement;
  approved: HTMLInputElement;
  requestType: HTMLInputElement;
  description: HTMLInputElement;
  requestor: HTMLInputElement;
}

interface RequestDetailsFormElements extends HTMLFormElement {
  readonly elements: RequestDetailsFormFields;
}

const Skeleton = styled('div')<{ height: number }>(({ theme, height }) => ({
  backgroundColor: theme.palette.action.hover,
  borderRadius: theme.shape.borderRadius,
  height,
  content: '" "',
}));

const Section = styled(Paper)(({ theme }) => ({
  backgroundColor: theme.palette.action.hover,
  borderRadius: theme.shape.borderRadius,
  width: '100%',
  height: '100%',
  padding: theme.spacing(2),
  ...theme.typography.body1,
  textAlign: 'left',
}));

export default function RequestDetails() {
  // const [priority, setPriority] = useState('');
  const [approval, setApproval] = useState('');
  const [type, setType] = useState('');
  const { id } = useParams<{ id: string }>();
  const dispatch = useAppDispatch();
  const request = useAppSelector((state) =>
    requestSelectors.selectById(state, id!)
  );
  const navigate = useNavigate();

  const { status } = useAppSelector((state) => state.request);

  useEffect(() => {
    if (!request && id) {
      dispatch(fetchRequestAsync(parseInt(id)));
    } else if (!request && !id) {
      navigate('/requests');
    }
  }, [id, request, dispatch, navigate]);

  const {
    requestTitle,
    description,
    requestor,
    approvalStatusName,
    requestTypeName,
  } = request;

  useEffect(() => {
    if (approvalStatusName === 'Approved') {
      setApproval(approvalStatusName);
    } else if (approvalStatusName === 'Denied') {
      setApproval(approvalStatusName);
    }

    if (requestTypeName === 'Project Request') {
      setType(requestTypeName);
    } else if (requestTypeName === 'Change Request') {
      setType(requestTypeName);
    }
  }, [setApproval, approvalStatusName, setType, requestTypeName]);

  const handleSubmit = async (
    e: React.FormEvent<RequestDetailsFormElements>
  ) => {
    e.preventDefault();

    let approveRequest = {};

    let requestType = {};

    if (approval === 'Approved') {
      approveRequest = {
        approvalStatusId: 1,
        approvalStatusName: 'Approved',
      };
    }

    if (approval === 'Denied') {
      approveRequest = {
        approvalStatusId: 2,
        approvalStatusName: 'Denied',
      };
    }

    if (type === 'Project Request') {
      requestType = {
        requestTypeId: 1,
        requestTypeName: 'Project Request',
      };
    }

    if (type === 'Change Request') {
      requestType = {
        requestTypeId: 2,
        requestTypeName: 'Change Request',
      };
    }

    if (id) {
      const updatedRequest = {
        ...request,
        requestId: id,
        approvalStatus: approveRequest,
        requestType: requestType,
      };
      dispatch(addApprovalStatus(updatedRequest));
      dispatch(setRequestType(updatedRequest));
      navigate(`/requests/${id}`);
    }
  };

  const handleApprovalChange = (e) => {
    setApproval(e.target.value);
  };

  const handleTypeChange = (e) => {
    setType(e.target.value);
  };

  const handleCABClick = (e) => {
    e.preventDefault();
    // dispatch(sendToCAB());
    // TODO: Implement sendToCAB
    // TODO: Navigate to Requests page
  };

  const handleCMClick = (e) => {
    e.preventDefault();
    // dispatch(sendToChangeManager());
    // TODO: Implement sendToChangeManager
    // TODO: Navigate to Requests page
  };

  if (status.includes('pending'))
    return <LoadingComponent message='Loading request...' />;

  /**
   * Need to show the status, approval status and request type.
   * Also need a way of showing the "stage" the request is in.
   *
   * Need a way of setting the different type of properties.
   * think change manager getting ready to move to cab board etc
   */

  return (
    <Paper sx={{ p: 2, width: '100%' }}>
      <PageContainer title={requestTitle} slots={{ toolbar: PageToolbar }}>
        <form onSubmit={handleSubmit}>
          <Grid container spacing={1}>
            <Grid size={12}>
              <Section>
                <Typography variant='h6'>Request Details</Typography>
              </Section>
            </Grid>

            <Grid size={12}>
              <Section>
                <Stack
                  direction='row'
                  spacing={2}
                  sx={{ justifyContent: 'space-between', alignItems: 'center' }}
                >
                  <Typography variant='body2'>
                    Requestor: {requestor.displayName}
                  </Typography>
                  <Typography variant='body2'>Status: Pending</Typography>
                </Stack>
              </Section>
            </Grid>
            <Grid size={12}>
              <Skeleton height={14} />
            </Grid>
            <Grid size={5}>
              <Section>
                <Stack
                  direction='column'
                  spacing={4}
                  sx={{ justifyContent: 'space-evenly', alignItems: 'stretch' }}
                >
                  <Typography variant='h6'>Request Actions</Typography>
                  <Divider />
                  <Tooltip
                    title='Approve or deny the request'
                    arrow
                    placement='left-start'
                  >
                    <FormControl>
                      <FormLabel>Approved?</FormLabel>
                      <RadioGroup
                        row
                        aria-label='approved'
                        name='approved'
                        value={approval}
                        onChange={handleApprovalChange}
                      >
                        <FormControlLabel
                          value='Approved'
                          control={
                            <Radio
                              checked={approval === 'Approved'}
                              size='small'
                            />
                          }
                          label='Approve'
                        />
                        <FormControlLabel
                          value='Denied'
                          control={
                            <Radio
                              checked={approval === 'Denied'}
                              size='small'
                            />
                          }
                          label='Denied'
                        />
                        <FormControlLabel
                          value='Pending'
                          control={
                            <Radio
                              checked={approval === 'Pending'}
                              size='small'
                            />
                          }
                          label='Pending'
                        />
                      </RadioGroup>
                    </FormControl>
                  </Tooltip>
                  <Divider />
                  <Tooltip
                    title='Set the type of request'
                    arrow
                    placement='left-start'
                  >
                    <FormControl>
                      <FormLabel>Request Type</FormLabel>
                      <RadioGroup
                        row
                        aria-label='requestType'
                        name='requestType'
                        value={type}
                        onChange={handleTypeChange}
                      >
                        <FormControlLabel
                          value='Project Request'
                          control={
                            <Radio
                              checked={type === 'Project Request'}
                              size='small'
                            />
                          }
                          label='Project Request'
                        />
                        <FormControlLabel
                          value='Change Request'
                          control={
                            <Radio
                              checked={type === 'Change Request'}
                              size='small'
                            />
                          }
                          label='Change Request'
                        />
                      </RadioGroup>
                    </FormControl>
                  </Tooltip>
                </Stack>
              </Section>
            </Grid>
            <Grid size={7}>
              {description.length === 0 ? (
                <Skeleton height={100} />
              ) : (
                <Section>
                  <Typography variant='h6'>Request Description</Typography>
                  <Divider sx={{ pt: 2 }} />
                  <Typography variant='body1' sx={{ pt: 2 }}>
                    {description}
                  </Typography>
                </Section>
              )}
            </Grid>
            <Grid size={12}>
              <Section>
                <Stack
                  direction='row'
                  spacing={2}
                  sx={{ justifyContent: 'space-between', alignItems: 'center' }}
                >
                  <Button type='submit' variant='contained' color='primary'>
                    Update
                  </Button>
                  <Stack direction='row' spacing={2}>
                    <Button
                      variant='contained'
                      color='success'
                      onClick={handleCABClick}
                    >
                      Send to CAB
                    </Button>
                    <Button
                      variant='contained'
                      color='info'
                      onClick={handleCMClick}
                    >
                      Send to Change Manager
                    </Button>
                  </Stack>
                </Stack>
              </Section>
            </Grid>
          </Grid>
        </form>
      </PageContainer>
    </Paper>
  );
}
