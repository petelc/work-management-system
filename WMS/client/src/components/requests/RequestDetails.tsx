import {
  Button,
  Divider,
  Grid2 as Grid,
  Typography,
  Paper,
} from '@mui/material';
import { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { useAppDispatch, useAppSelector } from '../../store/configureStore';
import {
  fetchRequestAsync,
  requestSelectors,
} from '../../pages/request/requestSlice';

import LoadingComponent from '../loading/LoadingComponent';
import { useTheme, styled } from '@mui/material/styles';
import { AppProvider, Navigation, PageContainer } from '@toolpad/core';
import { PageToolbar } from '../toolbar/PageToolbar';
import { Dashboard } from '@mui/icons-material';

const Skeleton = styled('div')<{ height: number }>(({ theme, height }) => ({
  backgroundColor: theme.palette.action.hover,
  borderRadius: theme.shape.borderRadius,
  height,
  content: '" "',
}));

const NAVIGATION: Navigation = [
  {
    segment: 'requests',
    title: 'Requests',
    icon: <Dashboard />,
  },
];

export default function RequestDetails() {
  const [priority, setPriority] = useState('');
  const theme = useTheme();
  const { id } = useParams<{ id: string }>();
  const dispatch = useAppDispatch();
  const request = useAppSelector((state) =>
    requestSelectors.selectById(state, id!)
  );
  const { status } = useAppSelector((state) => state.request);

  useEffect(() => {
    if (!request && id) dispatch(fetchRequestAsync(parseInt(id)));
  }, [id, request, dispatch]);

  function handlePriorityChange(event) {
    setPriority(event.target.value);
  }

  if (status.includes('pending'))
    return <LoadingComponent message='Loading request...' />;

  return (
    <AppProvider
      navigation={NAVIGATION}
      theme={theme}
      branding={{ title: 'WMS' }}
    >
      <Paper sx={{ p: 2, width: '100%' }}>
        <PageContainer slots={{ toolbar: PageToolbar }}>
          <Grid container spacing={1}>
            <Grid size={5} />
            <Grid size={12}>
              <Skeleton height={14} />
            </Grid>
            <Grid size={12}>
              <Skeleton height={14} />
            </Grid>
            <Grid size={4}>
              <Skeleton height={100} />
            </Grid>
            <Grid size={8}>
              <Skeleton height={100} />
            </Grid>
          </Grid>
        </PageContainer>
      </Paper>
    </AppProvider>
    // <Grid container spacing={12}>
    //   <Grid size={12}>
    //     <Typography variant='h2' sx={{ mb: 4 }}>
    //       {request.requestTitle}
    //     </Typography>
    //     <Typography variant='subtitle2'>{priority}</Typography>
    //     <Divider sx={{ mb: 2 }} />
    //     <Typography variant='body2'>{request.description}</Typography>
    //     <Button onClick={handlePriorityChange}>Priority</Button>
    //   </Grid>
    // </Grid>
  );
}
