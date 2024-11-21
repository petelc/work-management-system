import Grid from '@mui/material/Grid2';
import Box from '@mui/material/Box';
import Stack from '@mui/material/Stack';
import Typography from '@mui/material/Typography';

import StatCard from '../../components/maingrid/StatCard';
import CustomDataGrid from '../../components/charts/base/CustomDataGrid';
import useRequestCounts from '../../hooks/useRequestCounts';
import LoadingComponent from '../../components/loading/LoadingComponent';

export default function MainGrid() {
  const { requestCounts, countsLoaded } = useRequestCounts();

  if (!countsLoaded) return <LoadingComponent message='Loading counts...' />;

  return (
    <Box sx={{ width: '100%', maxWidth: { sm: '100%', md: '1700px' } }}>
      {/* cards */}
      <Typography component='h2' variant='h6' sx={{ mb: 2 }}>
        Overview
      </Typography>
      <Grid
        container
        spacing={2}
        columns={12}
        sx={{ mb: (theme) => theme.spacing(2) }}
      >
        {requestCounts.map((count, index) => (
          <Grid key={index} size={{ xs: 12, sm: 6, lg: 3 }}>
            <StatCard requestCounts={count} />
          </Grid>
        ))}
        <Grid size={{ xs: 12, sm: 6, lg: 3 }}>
          {/* <RequestCountCard /> */}
        </Grid>
        <Grid size={{ sm: 12, md: 6 }}>{/* <SessionsChart /> */}</Grid>
        <Grid size={{ sm: 12, md: 6 }}>{/* <PageViewsBarChart /> */}</Grid>
      </Grid>
      <Typography component='h2' variant='h6' sx={{ mb: 2 }}>
        Details
      </Typography>
      <Grid container spacing={2} columns={12}>
        <Grid size={{ md: 12, lg: 9 }}>
          <CustomDataGrid />
        </Grid>
        <Grid size={{ xs: 12, lg: 3 }}>
          <Stack gap={2} direction={{ xs: 'column', sm: 'row', lg: 'column' }}>
            {/* <CustomizedTreeView /> */}
            {/* <ChartUserByCountry /> */}
          </Stack>
        </Grid>
      </Grid>
      {/* <Copyright sx={{ my: 4 }} /> */}
    </Box>
  );
}
