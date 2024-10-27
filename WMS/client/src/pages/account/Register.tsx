import { LockOutlined } from '@mui/icons-material';
import {
  Container,
  Avatar,
  Paper,
  Typography,
  Box,
  TextField,
} from '@mui/material';
import Grid from '@mui/material/Grid2';
import { LoadingButton } from '@mui/lab';
import { useForm } from 'react-hook-form';
import { Link, useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';

import agent from '../../api/agent';

export default function Register() {
  const navigate = useNavigate();
  const {
    register,
    handleSubmit,
    //setError,
    formState: { isSubmitting, errors, isValid },
  } = useForm({
    mode: 'onTouched',
  });

  //   function handleApiErrors(errors: any) {
  //     console.log(errors);
  //     if (errors) {
  //       errors.foreach((error: string) => {
  //         if (error.includes('Password')) {
  //           setError('password', { message: error });
  //         } else if (error.includes('Email')) {
  //           setError('email', { message: error });
  //         } else if (error.includes('Display Name')) {
  //           setError('displayName', { message: error });
  //         } else if (error.includes('Username')) {
  //           setError('username', { message: error });
  //         }
  //       });
  //     }
  //   }

  return (
    <Container
      component={Paper}
      maxWidth='sm'
      sx={{
        p: 4,
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        mt: { xs: 14, sm: 20 },
      }}
    >
      <Avatar sx={{ m: 1, bgcolor: 'secondary-main' }}>
        <LockOutlined />
      </Avatar>
      <Typography component='h1' variant='h5'>
        Register
      </Typography>
      <Box
        component='form'
        autoComplete='off'
        onSubmit={handleSubmit((data) =>
          agent.Account.register(data)
            .then(() => {
              toast.success('Registration successful - you can now login');
              navigate('/login');
            })
            .catch((error) => console.log(error))
        )}
        noValidate
        sx={{ mt: 1 }}
      >
        <TextField
          margin='normal'
          required
          fullWidth
          autoFocus
          label='Display Name'
          {...register('displayName', { required: 'Display Name is required' })}
          error={!!errors.displayValue}
          helperText={errors?.displayName?.message as string}
        />
        <TextField
          margin='normal'
          required
          fullWidth
          autoFocus
          label='Username'
          {...register('username', { required: 'Username is required' })}
          error={!!errors.username}
          helperText={errors?.username?.message as string}
        />
        <TextField
          margin='normal'
          required
          fullWidth
          label='Email'
          {...register('email', {
            required: 'Email is required',
            pattern: {
              value: /^\w+[\w-.]*@\w+((-\w+)|(\w*))\.[a-z]{2,3}$/,
              message: 'Not a valid email address',
            },
          })}
          error={!!errors.email}
          helperText={errors?.email?.message as string}
        />
        <TextField
          margin='normal'
          required
          fullWidth
          type='password'
          label='Password'
          {...register('password', {
            required: 'Password is required',
            pattern: {
              value:
                /(?=^.{6,10}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$/,
              message: 'Password does not meet complexity requirements',
            },
          })}
          error={!!errors.password}
          helperText={errors?.password?.message as string}
        />
        <LoadingButton
          loading={isSubmitting}
          disabled={!isValid}
          type='submit'
          fullWidth
          variant='contained'
          color='secondary'
          sx={{ mt: 3, mb: 2 }}
        >
          Sign In
        </LoadingButton>
        <Grid container>
          <Grid>
            <Link to='/login' style={{ textDecoration: 'none' }}>
              {'Already have an account? Sign In'}
            </Link>
          </Grid>
        </Grid>
      </Box>
    </Container>
  );
}
