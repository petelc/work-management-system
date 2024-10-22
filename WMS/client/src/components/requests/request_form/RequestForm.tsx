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
  // ! handle state and functions here
  const [titleError, setTitleError] = useState(false);
  const [titleErrorMessage, setTitleErrorMessage] = useState('');

  const validateInputs = () => {
    const title = document.getElementById('title') as HTMLInputElement;

    let isValid = true;

    if (!title.value) {
      setTitleError(true);
      setTitleErrorMessage('Request Title is Required');
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
            error={titleError}
            helperText={titleErrorMessage}
            id='title'
            type='text'
            name='title'
            placeholder='title of request'
            autoFocus
            required
            fullWidth
            variant='outlined'
            color={titleError ? 'error' : 'primary'}
            sx={{ ariaLabel: 'title' }}
          />
        </FormControl>
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
