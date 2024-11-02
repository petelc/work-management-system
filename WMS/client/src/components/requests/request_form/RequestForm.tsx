import { useState } from 'react';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
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
import { InputAdornment } from '@mui/material';
import { Description, Title } from '@mui/icons-material';

import useFetchRequestTypes from '../../../hooks/useFetchRequestTypes';
import RequestTypeSelect from '../../requesttypeselect/RequestTypeSelect';
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
  // ! handle state and functions here
  const [titleError, setTitleError] = useState(false);
  const [titleErrorMessage, setTitleErrorMessage] = useState('');
  const [descriptionError, setDescriptionError] = useState(false);
  const [descriptionErrorMessage, setDescriptionErrorMessage] = useState('');

  const validateInputs = () => {
    const title = document.getElementById('title') as HTMLInputElement;
    const description = document.getElementById(
      'description'
    ) as HTMLInputElement;

    let isValid = true;

    if (!title.value) {
      setTitleError(true);
      setTitleErrorMessage('Request title is required');
      isValid = false;
    }

    if (!description.value) {
      setDescriptionError(true);
      setDescriptionErrorMessage('Request description is required!');
      isValid = false;
    }

    return isValid;
  };

  const handleSubmit = () => {};

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
        onSubmit={handleSubmit}
        noValidate
        sx={{ display: 'flex', flexDirection: 'column', width: '100%', gap: 2 }}
      >
        <FormControl>
          <FormLabel htmlFor='requestTitle'>Request Title</FormLabel>
          <TextField
            margin='normal'
            error={titleError}
            helperText={titleErrorMessage}
            id='title'
            type='text'
            name='title'
            autoFocus
            required
            fullWidth
            variant='filled'
            color={titleError ? 'error' : 'primary'}
            sx={{ ariaLabel: 'title' }}
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
            name='description'
            type='text'
            multiline
            variant='filled'
            fullWidth
            error={descriptionError}
            helperText={descriptionErrorMessage}
            color={descriptionError ? 'error' : 'primary'}
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
        <RequestTypeSelect items={types} />
        <Button
          type='submit'
          fullWidth
          variant='contained'
          onClick={validateInputs}
        >
          Submit Request
        </Button>
      </Box>
    </Card>
  );
}
