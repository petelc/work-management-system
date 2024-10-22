import Grid from '@mui/material/Grid2';
import Paper from '@mui/material/Paper';
import RequestLists from '../../components/requests/RequestList';
import AppPagination from '../../components/pagination/AppPagination';
import useRequests from '../../hooks/useRequests';
import { setPageNumber } from './requestSlice';
import { useAppDispatch } from '../../store/configureStore';
import LoadingComponent from '../../components/loading/LoadingComponent';
import { Container } from '@mui/material';
//import RadioButtonGroup from '../../components/radiobuttongroup/RadioButtonGroup';
//import CheckboxButtons from '../../components/checkboxbuttons/CheckboxButtons';

// const sortOptions = [
//   { value: 'title', label: 'Alphabetical' },
//   { value: 'priority', label: 'Alphabetical' },
//   { value: 'category', label: 'Alphabetical' },
// ];

export default function Request() {
  const { requests, filtersLoaded, metaData } = useRequests();
  //const { requestParams } = useAppSelector((state) => state.request);
  const dispatch = useAppDispatch();

  if (!filtersLoaded) return <LoadingComponent message='Loading requests...' />;

  return (
    <Container
      sx={{
        // display: 'flex',
        // flexDirection: 'row',
        // alignItems: 'center',
        pt: { xs: 14, sm: 20 },
        pb: { xs: 8, sm: 12 },
      }}
    >
      <Grid container columnSpacing={4}>
        <Grid size={{ xs: 3 }}>
          <Paper sx={{ mb: 2 }}>
            <p>Search coming Soon</p>
          </Paper>
          <Paper sx={{ p: 2, mb: 2 }}>
            {/* <RadioButtonGroup
            selectedValue={requestParams.orderBy}
            options={sortOptions}
            onChange={(e) =>
              dispatch(setRequestParams({ orderBy: e.target.value }))
            }
          /> */}
          </Paper>
          <Paper sx={{ p: 2, mb: 2 }}>
            {/* <CheckboxButtons
              items={approvalStatus}
              checked={approvalStatus}
              onChange={(items: string[]) =>
                dispatch(setRequestParams({ approvalStatus: items }))
              }
            /> */}
          </Paper>
          <Paper sx={{ p: 2, mb: 2 }}>
            {/* <CheckboxButtons
            items={types}
            checked={requestParams.types}
            onChange={(items: string[]) =>
              dispatch(setRequestParams({ types: items }))
            }
          /> */}
          </Paper>
        </Grid>
        <Grid size={{ xs: 9 }}>
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
    </Container>
  );
}
