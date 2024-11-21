import Stack from '@mui/material/Stack';
import Container from '@mui/material/Container';
import RequestForm from './RequestForm';
import Content from './Content';

export default function RequestSide() {
  return (
    <Container
      sx={{
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        pt: { xs: 8, sm: 12 },
        pb: { xs: 8, sm: 12 },
      }}
    >
      <Stack
        direction='column'
        component='main'
        sx={{
          justifyContent: 'space-between',
          height: { xs: 'auto', md: '100%' },
        }}
      >
        <Stack
          direction={{ xs: 'column-reverse', md: 'row' }}
          sx={{
            justifyContent: 'center',
            gap: { xs: 6, sm: 12 },
            p: { xs: 2, sm: 4 },
            m: 'auto',
          }}
        >
          <Content />
          <RequestForm />
        </Stack>
      </Stack>
    </Container>
  );
}
