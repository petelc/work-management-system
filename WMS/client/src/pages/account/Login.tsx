import { LockOutlined } from '@mui/icons-material';
import {
  Container,
  Paper,
  Avatar,
  Typography,
  Box,
  TextField,
} from '@mui/material';
import Grid from '@mui/material/Grid2';
import { Link, useLocation, useNavigate } from 'react-router-dom';
import { FieldValues, useForm } from 'react-hook-form';
import { LoadingButton } from '@mui/lab';
import { useAppDispatch } from '../../store/configureStore';
import { signInUser } from './accountSlice';

export default function Login() {
  const navigate = useNavigate();
  const location = useLocation();
  const dispatch = useAppDispatch();
  const {
    register,
    handleSubmit,
    formState: { isSubmitting, errors, isValid },
  } = useForm({ mode: 'onTouched' });

  async function submitForm(data: FieldValues) {
    console.log(data);
    try {
      await dispatch(signInUser(data));
      navigate(location.state?.from || '/dashboard');
    } catch (error) {
      console.log(error);
    }
  }

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
      <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
        <LockOutlined />
      </Avatar>
      <Typography component='h1' variant='h5'>
        Sign In
      </Typography>
      <Box
        component='form'
        onSubmit={handleSubmit(submitForm)}
        noValidate
        //sx={{ mt: 1 }}
      >
        <TextField
          margin='normal'
          fullWidth
          label='Email'
          autoComplete='email'
          autoFocus
          {...register('email', { required: 'Email is required' })}
          error={!!errors.email}
          helperText={errors.email?.message as string}
        />
        <TextField
          margin='normal'
          fullWidth
          label='Password'
          type='password'
          autoComplete='current-password'
          {...register('password', { required: 'Password is required' })}
          error={!!errors.password}
          helperText={errors.password?.message as string}
        />
        <LoadingButton
          loading={isSubmitting}
          disabled={!isValid}
          type='submit'
          fullWidth
          variant='contained'
          color='secondary'
          sx={{
            mt: 3,
            mb: 2,
          }}
        >
          Sign In
        </LoadingButton>
        <Grid container>
          <Grid>
            <Link to='/register' style={{ textDecoration: 'none' }}>
              {"Don't have and account? Sign Up"}
            </Link>
          </Grid>
        </Grid>
      </Box>
    </Container>
  );
}
