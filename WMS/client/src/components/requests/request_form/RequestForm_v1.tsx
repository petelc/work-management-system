//import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import Box from '@mui/material/Box';
import FormLabel from '@mui/material/FormLabel';
import FormControl from '@mui/material/FormControl';
import TextField from '@mui/material/TextField';
//import Typography from '@mui/material/Typography';
import { Autocomplete, Chip, InputAdornment, Paper } from '@mui/material';
import { Description, Title } from '@mui/icons-material';
import { LoadingButton } from '@mui/lab';
import { useForm } from 'react-hook-form';
import { toast } from 'react-toastify';
import { PageContainer } from '@toolpad/core';

import useFetchRequestTypes from '../../../hooks/useFetchRequestTypes';
import agent from '../../../api/agent';
import useFetchRequestors from '../../../hooks/useFetchRequestors';
//import { User } from '../../../models/user';

export default function RequestForm() {
  const { types } = useFetchRequestTypes();
  const { users } = useFetchRequestors();
  const {
    register,
    handleSubmit,
    setError,
    formState: { errors, isValid },
  } = useForm({ mode: 'onTouched' });
  const navigate = useNavigate();

  console.log(types);

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
        } else if (error.includes('displayName')) {
          setError('requestor', { message: error });
        }
      });
    }
  }

  return (
    <Paper sx={{ p: 2, width: '100%' }}>
      <PageContainer>
        <Box sx={{ display: { xs: 'flex', md: 'none' } }}>WMS</Box>
        <Box
          component='form'
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
          noValidate
          sx={{
            display: 'flex',
            flexDirection: 'column',
            width: '100%',
            gap: 2,
          }}
        >
          <FormControl>
            <FormLabel htmlFor='requestTitle'>Request Title</FormLabel>
            <TextField
              margin='normal'
              id='requestTitle'
              type='text'
              autoFocus
              required
              fullWidth
              variant='outlined'
              {...register('requestTitle', {
                required: 'Request title is required!',
              })}
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
          </FormControl>
          <FormControl>
            <FormLabel htmlFor='description'>Description</FormLabel>
            <TextField
              margin='normal'
              id='description'
              type='text'
              multiline
              variant='outlined'
              fullWidth
              {...register('description', {
                required: 'Request description is required!',
              })}
              error={!!errors.description}
              color={errors.description ? 'error' : 'primary'}
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
          </FormControl>
          {/* <FormControl>
            <Autocomplete
              freeSolo
              id='requestType'
              options={types.map((type: any) => type)}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label='Type of Request'
                  margin='normal'
                  variant='outlined'
                  {...register('requestType')}
                  sx={{ ariaLabel: 'requestType' }}
                />
              )}
            />
          </FormControl> */}
          <FormControl>
            {/* <FormLabel htmlFor='requestors'>Requestors</FormLabel> */}
            <Autocomplete
              multiple
              freeSolo
              size='medium'
              id='requestors'
              options={users.map((user: any) => user.displayName)}
              renderTags={(value: readonly string[], getTagProps) =>
                value.map((option: string, index: number) => {
                  const { key, ...tagProps } = getTagProps({ index });
                  return (
                    <Chip
                      variant='filled'
                      label={option}
                      key={key}
                      {...tagProps}
                    />
                  );
                })
              }
              renderInput={(params) => (
                <TextField
                  {...params}
                  label='Requestors'
                  margin='normal'
                  variant='outlined'
                  {...register('requestors')}
                  sx={{ ariaLabel: 'requestors' }}
                />
              )}
            />
          </FormControl>
          <LoadingButton
            // loading={isSubmitting}
            disabled={!isValid}
            type='submit'
            fullWidth
            variant='contained'
            color='secondary'
          >
            Submit Request
          </LoadingButton>
        </Box>
      </PageContainer>
    </Paper>
  );
}
