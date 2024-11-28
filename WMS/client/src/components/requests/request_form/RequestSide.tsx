import Container from '@mui/material/Container';
import RequestForm from './RequestForm';

export default function RequestSide() {
  return (
    <Container
      sx={{
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        width: '100%',
        pt: { xs: 8, sm: 12 },
        pb: { xs: 8, sm: 12 },
      }}
    >
      <RequestForm />
    </Container>
  );
}
