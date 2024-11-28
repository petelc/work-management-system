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
import { styled } from '@mui/material/styles';
import { PageContainer } from '@toolpad/core';
import { PageToolbar } from '../toolbar/PageToolbar';

const Skeleton = styled('div')<{ height: number }>(({ theme, height }) => ({
  backgroundColor: theme.palette.action.hover,
  borderRadius: theme.shape.borderRadius,
  height,
  content: '" "',
}));

const Section = styled(Paper)(({ theme }) => ({
  backgroundColor: theme.palette.action.hover,
  borderRadius: theme.shape.borderRadius,
  width: '100%',
  height: '100%',
  padding: theme.spacing(2),
  ...theme.typography.body1,
  textAlign: 'left',
}));

export default function RequestDetails() {
  const [priority, setPriority] = useState('');
  const { id } = useParams<{ id: string }>();
  const dispatch = useAppDispatch();
  const request = useAppSelector((state) =>
    requestSelectors.selectById(state, id!)
  );
  const { status } = useAppSelector((state) => state.request);

  useEffect(() => {
    if (!request && id) dispatch(fetchRequestAsync(parseInt(id)));
  }, [id, request, dispatch]);

  const { requestTitle, description } = request;

  function handlePriorityChange(event) {
    setPriority(event.target.value);
  }

  if (status.includes('pending'))
    return <LoadingComponent message='Loading request...' />;

  console.log(request);

  /**
   * Need to show the status, approval status and request type.
   * Also need a way of showing the "stage" the request is in.
   *
   * Need a way of setting the different type of properties.
   * think change manager getting ready to move to cab board etc
   */

  return (
    <Paper sx={{ p: 2, width: '100%' }}>
      <PageContainer title={requestTitle} slots={{ toolbar: PageToolbar }}>
        <Grid container spacing={1}>
          <Grid size={5} />
          <Grid size={12}>
            <Skeleton height={14} />
          </Grid>
          <Grid size={12}>
            <Skeleton height={14} />
          </Grid>
          <Grid size={4}>
            <Skeleton height={200} />
          </Grid>
          <Grid size={8}>
            {description.length === 0 ? (
              <Skeleton height={100} />
            ) : (
              <Section>
                <Typography variant='h6'>Request Description</Typography>
                <Typography variant='body1'>{description}</Typography>
              </Section>
            )}
          </Grid>
        </Grid>
      </PageContainer>
    </Paper>
  );
}
