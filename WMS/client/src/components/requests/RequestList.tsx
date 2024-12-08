import Grid from '@mui/material/Grid2';

import { Request } from '../../models/request';
import { useAppSelector } from '../../store/configureStore';

import RequestCardSkeleton from './RequestCardSkeleton';
import RequestCard from './RequestCard';

interface Props {
  requests: Request[];
}

export default function RequestLists({ requests }: Props) {
  const { requestsLoaded } = useAppSelector((state) => state.request);
  console.log(requests);
  return (
    <Grid
      container
      spacing={2}
      columns={12}
      sx={{ mb: (theme) => theme.spacing(2) }}
    >
      {requests.map((request) => (
        <Grid size={{ xs: 12, sm: 6, lg: 3 }} key={request.requestId}>
          {!requestsLoaded ? (
            <RequestCardSkeleton />
          ) : (
            <RequestCard request={request} />
          )}
        </Grid>
      ))}
    </Grid>
  );
}
