import Grid from '@mui/material/Grid2';
import Paper from '@mui/material/Paper';
import Box from '@mui/material/Box';
import RequestLists from '../../components/requests/RequestList';
import AppPagination from '../../components/pagination/AppPagination';
import useRequests from '../../hooks/useRequests';
import { setPageNumber, setRequestParams } from './requestSlice';
import { useAppDispatch, useAppSelector } from '../../store/configureStore';
import LoadingComponent from '../../components/loading/LoadingComponent';
// import { Container } from '@mui/material';
import RequestSearch from '../../components/requests/RequestSearch';
import RadioButtonGroup from '../../components/radiobuttongroup/RadioButtonGroup';
//import CheckboxButtons from '../../components/checkboxbuttons/CheckboxButtons';

const sortOptions = [
  { value: 'title', label: 'By Title' },
  { value: 'priority', label: 'By Priority' },
  { value: 'category', label: 'By Category' },
];

export default function Request() {
  const { requests, filtersLoaded, metaData } = useRequests();
  const { requestParams } = useAppSelector((state) => state.request);
  const dispatch = useAppDispatch();

  //console.log(requests);

  if (!filtersLoaded) return <LoadingComponent message='Loading requests...' />;

  return (
    // <Container
    //   sx={{
    //     pt: { xs: 14, sm: 20 },
    //     pb: { xs: 8, sm: 12 },
    //   }}
    // >
    <Box sx={{ width: '100%', maxWidth: { sm: '100%', md: '1700px' } }}>
      <Grid container columnSpacing={3}>
        <Grid size={{ xs: 12 }}>
          <Paper sx={{ mb: 2 }}>
            <RequestSearch />
          </Paper>
          <Paper sx={{ p: 2, mb: 4 }}>
            <RadioButtonGroup
              selectedValue={requestParams.orderBy}
              options={sortOptions}
              onChange={(e) =>
                dispatch(setRequestParams({ orderBy: e.target.value }))
              }
            />
          </Paper>
        </Grid>
        <Grid size={{ xs: 12 }}>
          <RequestLists requests={requests} />
        </Grid>
        <Grid size={{ xs: 3 }} />
        <Grid size={{ xs: 9 }} sx={{ mb: 2 }}>
          {metaData && (
            <AppPagination
              metaData={metaData}
              onPageChange={(page: number) =>
                dispatch(setPageNumber({ pageNumber: page }))
              }
            />
          )}
        </Grid>
      </Grid>
    </Box>
    // </Container>
  );
}
