import { useNavigate } from 'react-router-dom';
import Box from '@mui/material/Box';
import { InputAdornment, Paper, Stack } from '@mui/material';
import { Description, Title } from '@mui/icons-material';
import { LoadingButton } from '@mui/lab';
import { TextFieldElement, AutocompleteElement } from 'react-hook-form-mui';
import { useForm } from 'react-hook-form';
import { toast } from 'react-toastify';
import { PageContainer } from '@toolpad/core';

import agent from '../../../api/agent';
import useFetchRequestors from '../../../hooks/useFetchRequestors';

const types = [
  {
    id: 1,
    RequestTypeId: 1,
    RequestTypeName: 'Project Request',
    label: 'Project Request',
  },
  {
    id: 2,
    RequestTypeId: 2,
    RequestTypeName: 'Change Request',
    label: 'Change Request',
  },
];

const statuses = [
  { id: 1, StatusId: 1, StatusName: 'In Progress', label: 'In Progress' },
  { id: 2, StatusId: 2, StatusName: 'On Hold', label: 'On Hold' },
  { id: 3, StatusId: 3, StatusName: 'Cancelled', label: 'Cancelled' },
  { id: 4, StatusId: 4, StatusName: 'Completed', label: 'Completed' },
  { id: 5, StatusId: 5, StatusName: 'Pending', label: 'Pending' },
];

const approvals = [
  {
    id: 1,
    ApprovalStatusId: 1,
    ApprovalStatusName: 'Approved',
    label: 'Approved',
  },
  {
    id: 2,
    ApprovalStatusId: 2,
    ApprovalStatusName: 'Rejected',
    label: 'Rejected',
  },
  {
    id: 3,
    ApprovalStatusId: 3,
    ApprovalStatusName: 'Pending',
    label: 'Pending',
  },
];

export default function RequestForm() {
  //const { types } = useFetchRequestTypes();
  const { users } = useFetchRequestors();
  const {
    control,
    handleSubmit,
    setError,
    formState: { errors, isValid },
  } = useForm<{
    requestTitle: string;
    description: string;
    requestType: string;
    requestor: {};
    isNew: boolean;
    status?: {};
    approvalStatus?: {};
  }>({
    defaultValues: {
      requestTitle: '',
      description: '',
      requestor: {},
      isNew: true,
    },
  });
  const navigate = useNavigate();
  console.log(users);

  const requestors = users.map(
    (user: any) =>
      new Object({
        id: user.id,
        label: user.displayName,
        displayName: user.displayName,
        lastName: user.lastName,
        firstName: user.firstName,
        user: user,
      })
  );

  function handleApiErrors(errors: any) {
    console.log(errors);
    if (errors) {
      errors.forEach((error: string) => {
        if (error.includes('requestTitle')) {
          setError('requestTitle', { message: error });
        } else if (error.includes('description')) {
          setError('description', { message: error });
        } else if (error.includes('requestType')) {
          setError('requestType', { message: error });
        }
      });
    }
  }

  return (
    <Paper sx={{ p: 2, width: '100%' }}>
      <PageContainer>
        <Box sx={{ display: { xs: 'flex', md: 'none' } }}>WMS</Box>
        <Box
          sx={{
            display: 'flex',
            flexDirection: 'column',
            width: '100%',
            gap: 4,
          }}
        >
          <form
            onSubmit={handleSubmit((data) =>
              agent.UserRequest.create(data)
                .then((response) => {
                  const token = response.data.token;
                  localStorage.setItem('authToken', token);
                  toast.success('Request submitted successfully!');
                  navigate('/');
                })
                .catch((error) => handleApiErrors(error))
            )}
          >
            <Stack spacing={2}>
              <TextFieldElement
                margin='normal'
                id='requestTitle'
                type='text'
                name={'requestTitle'}
                label={'Request Title'}
                autoFocus
                required
                fullWidth
                control={control}
                variant='outlined'
                error={!!errors.requestTitle}
                color={errors.requestTitle ? 'error' : 'primary'}
                sx={{ ariaLabel: 'requestTitle' }}
                slotProps={{
                  input: {
                    startAdornment: (
                      <InputAdornment position='start'>
                        <Title />
                      </InputAdornment>
                    ),
                  },
                }}
              />

              <TextFieldElement
                margin='normal'
                id='description'
                type='text'
                name={'description'}
                label={'Description'}
                control={control}
                multiline
                variant='outlined'
                fullWidth
                sx={{ ariaLabel: 'description' }}
                slotProps={{
                  input: {
                    startAdornment: (
                      <InputAdornment position='start'>
                        <Description />
                      </InputAdornment>
                    ),
                  },
                }}
              />

              <AutocompleteElement
                name={'requestType'}
                label={'Type of Request'}
                options={types}
                control={control}
              />

              <AutocompleteElement
                name={'requestor'}
                label={'Requestor'}
                options={requestors}
                control={control}
              />

              <AutocompleteElement
                name={'status'}
                label={'Status'}
                options={statuses}
                control={control}
              />

              <AutocompleteElement
                name={'approvalStatus'}
                label={'Approval Status'}
                options={approvals}
                control={control}
              />

              <LoadingButton
                // loading={isSubmitting}
                disabled={!isValid}
                type={'submit'}
                fullWidth
                variant='contained'
                color={'secondary'}
              >
                Submit Request
              </LoadingButton>
            </Stack>
          </form>
        </Box>
      </PageContainer>
    </Paper>
  );
}
