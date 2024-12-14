import Grid from '@mui/material/Grid2';
import Paper from '@mui/material/Paper';
import Box from '@mui/material/Box';
//import AppPagination from '../../components/pagination/AppPagination';
import useRequests from '../../hooks/useRequests';
//import { setPageNumber } from './requestSlice';
//import { useAppDispatch } from '../../store/configureStore';
import LoadingComponent from '../../components/loading/LoadingComponent';
import RequestSearch from '../../components/requests/RequestSearch';
import RequestTable from '../../components/requests/RequestTable';

export default function Request() {
  const { requests, filtersLoaded } = useRequests();

  if (!filtersLoaded) return <LoadingComponent message='Loading requests...' />;

  return (
    <Box sx={{ width: '100%', maxWidth: { sm: '100%', md: '1700px' } }}>
      <Grid container columnSpacing={3}>
        <Grid size={{ xs: 12 }}>
          <Paper sx={{ mb: 2 }}>
            <RequestSearch />
          </Paper>
        </Grid>
        <Grid size={{ xs: 12 }}>
          <RequestTable requests={requests} />
        </Grid>
        <Grid size={{ xs: 3 }} />
      </Grid>
    </Box>
  );
}
