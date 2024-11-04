//import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import Box from '@mui/material/Box';
import MuiCard from '@mui/material/Card';
//import Checkbox from '@mui/material/Checkbox';
//import Divider from '@mui/material/Divider';
import FormLabel from '@mui/material/FormLabel';
import FormControl from '@mui/material/FormControl';
//import FormControlLabel from '@mui/material/FormControlLabel';
//import Link from '@mui/material/Link';
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import { styled } from '@mui/material/styles';
import {
  InputAdornment,
  InputLabel,
  ListItemText,
  MenuItem,
  Select,
} from '@mui/material';
import { Description, Title } from '@mui/icons-material';
import { LoadingButton } from '@mui/lab';
import { useForm } from 'react-hook-form';
import { toast } from 'react-toastify';

import useFetchRequestTypes from '../../../hooks/useFetchRequestTypes';
//import RequestTypeSelect from '../../requesttypeselect/RequestTypeSelect';
import agent from '../../../api/agent';
//import { useAppDispatch, useAppSelector } from '../../../store/configureStore';

const Card = styled(MuiCard)(({ theme }) => ({
  display: 'flex',
  flexDirection: 'column',
  alignSelf: 'center',
  width: '100%',
  padding: theme.spacing(4),
  gap: theme.spacing(2),
  boxShadow:
    'hsla(220, 30%, 5%, 0.05) 0px 5px 15px 0px, hsla(220, 25%, 10%, 0.05) 0px 15px 35px -5px',
  [theme.breakpoints.up('sm')]: {
    width: '450px',
  },
  ...theme.applyStyles('dark', {
    boxShadow:
      'hsla(220, 30%, 5%, 0.5) 0px 5px 15px 0px, hsla(220, 25%, 10%, 0.08) 0px 15px 35px -5px',
  }),
}));

export default function RequestForm() {
  const { types } = useFetchRequestTypes();
  const {
    register,
    handleSubmit,
    setError,
    setValue,
    formState: { errors, isValid },
  } = useForm({ mode: 'onTouched' });
  const navigate = useNavigate();

  // TODO - figure out how to handle errors for the request type select list

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
    <Card variant='outlined'>
      <Box sx={{ display: { xs: 'flex', md: 'none' } }}>WMS</Box>
      <Typography
        component='h1'
        variant='h4'
        sx={{ width: '100%', fontSize: 'clamp(2rem, 10vw, 2.15rem)' }}
      >
        Submit Request
      </Typography>
      <Box
        component='form'
        onSubmit={handleSubmit((data) =>
          agent.UserRequest.create(data)
            .then(() => {
              toast.success('Request submitted successfully!');
              navigate('/');
            })
            .catch((error) => handleApiErrors(error))
        )}
        noValidate
        sx={{ display: 'flex', flexDirection: 'column', width: '100%', gap: 2 }}
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
            variant='filled'
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
            variant='filled'
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
        <FormControl variant='filled'>
          <InputLabel id='type'>Type of Request</InputLabel>

          <Select
            labelId='type'
            id='requestType'
            fullWidth
            defaultValue=''
            onChange={(event) => {
              setValue('requestTypeName', event.target.value);
            }}
            {...register}
            error={!!errors.requestType}
          >
            <MenuItem value=''>
              <em>None</em>
            </MenuItem>
            {types.map((name) => (
              <MenuItem key={name} value={name}>
                <ListItemText primary={name} />
              </MenuItem>
            ))}
          </Select>
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
    </Card>
  );
}
