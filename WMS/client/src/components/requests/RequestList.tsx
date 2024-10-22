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

  return (
    <Grid container spacing={4}>
      {requests.map((request) => (
        <Grid size={{ xs: 4 }} key={request.id}>
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
