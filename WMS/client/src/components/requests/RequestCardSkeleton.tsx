import {
  Grid2 as Grid,
  Card,
  CardHeader,
  Skeleton,
  CardContent,
  CardActions,
} from '@mui/material';

export default function RequestCardSkeleton() {
  return (
    <Grid size={{ xs: 2 }} component={Card}>
      <CardHeader
        avatar={
          <Skeleton
            animation='wave'
            variant='circular'
            width={40}
            height={40}
          />
        }
      />
      <Skeleton sx={{ height: 190 }} animation='wave' variant='rectangular' />
      <CardContent>
        <>
          <Skeleton animation='wave' height={10} style={{ marginBottom: 6 }} />
          <Skeleton animation='wave' height={10} width='80%' />
        </>
      </CardContent>
      <CardActions>
        <>
          <Skeleton animation='wave' height={10} width='40%' />
          <Skeleton animation='wave' height={10} width='20%' />
        </>
      </CardActions>
    </Grid>
  );
}
