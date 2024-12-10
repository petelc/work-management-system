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
} from '@mui/material';
import { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { styled } from '@mui/material/styles';
import { PageContainer } from '@toolpad/core';
import { PageToolbar } from '../toolbar/PageToolbar';
//import { toast } from 'react-toastify';

import { useAppDispatch, useAppSelector } from '../../store/configureStore';
import {
  addApprovalStatus,
  fetchRequestAsync,
  requestSelectors,
} from '../../pages/request/requestSlice';

import LoadingComponent from '../loading/LoadingComponent';
//import agent from '../../api/agent';
//import { useForm } from 'react-hook-form';

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
  //const navigate = useNavigate();

  const { status } = useAppSelector((state) => state.request);

  useEffect(() => {
    if (!request && id) dispatch(fetchRequestAsync(parseInt(id)));
  }, [id, request, dispatch]);

  const { requestTitle, description, requestor } = request;

  console.log(request);

  // function handlePriorityChange(event) {
  //   setPriority(event.target.value);
  // }

  function handleApprovalStatusChange(event) {
    setApproval(event.target.value);

    if (approval === 'Approved') {
      //const updatedApprovalStatus = approval;
      dispatch(
        addApprovalStatus({
          requestId: request.requestId,
          approvalStatusName: approval,
        })
      );
    }

    // if (event.target.value === 'Approved') {
    //   request.approvalStatus = new Object({
    //     approvalStatusId: 1,
    //     approvalStatus: 'Approved',
    //   });
    // } else if (event.target.value === 'Denied') {
    //   request.approvalStatus = new Object({
    //     approvalStatusId: 2,
    //     approvalStatus: 'Denied',
    //   });
    // }

    //request.approvalStatus = event.target.value;
    // agent.UserRequest.approve({
    //   request,
    // })
    //   .then((response) => {
    //     console.log(response);
    //     toast.success('Request approved successfully!');
    //   })
    //   .catch((error) => console.log(error));
  }

  function handleRequestTypeChange(event) {
    setType(event.target.value);
  }

  if (status.includes('pending'))
    return <LoadingComponent message='Loading request...' />;

  console.log(request);

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
                      onChange={handleApprovalStatusChange}
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
                          <Radio checked={approval === 'Denied'} size='small' />
                        }
                        label='Denied'
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
                      onChange={handleRequestTypeChange}
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
        </Grid>
      </PageContainer>
    </Paper>
  );
}
