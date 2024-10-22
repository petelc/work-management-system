import {
  Button,
  Card,
  CardActions,
  CardContent,
  CardHeader,
  Typography,
} from '@mui/material';
import { Link } from 'react-router-dom';
import { LoadingButton } from '@mui/lab';

import { Request } from '../../models/request';
//import { useAppDispatch, useAppSelector } from '../../store/configureStore';

interface Props {
  request: Request;
}

export default function RequestCard({ request }: Props) {
  //const { status } = useAppSelector((state) => state.request);
  //const dispatch = useAppDispatch();

  const { requestTitle, description, approvalStatus, requestType, status } =
    request;

  console.log(requestTitle, description, approvalStatus, requestType, status);
  const { approvalStatusName } = approvalStatus;
  const { requestTypeName } = requestType;
  const { statusName } = status;

  return (
    <Card>
      <CardHeader
        // avatar={
        //   <Avatar sx={{ bgColor: 'secondary.main' }}>
        //     {request.requestTitle.charAt(0).toUpperCase()}
        //   </Avatar>
        // }
        title={requestTitle}
        titleTypographyProps={{
          sx: { fontWeight: 'bold', color: 'primary.main' },
        }}
      />

      <CardContent>
        <Typography variant='h5' color='text.light'>
          {description}
        </Typography>
        <Typography
          gutterBottom
          color='text.secondary'
          variant='body2'
          component='div'
        >
          {approvalStatusName}
        </Typography>
        <Typography variant='body2' color='text.secondary'>
          {requestTypeName} / {statusName}
        </Typography>
      </CardContent>
      <CardActions>
        <LoadingButton size='small'>Submit to Board</LoadingButton>
        <Button component={Link} to={`/request/${request.id}`} size='small'>
          View
        </Button>
      </CardActions>
    </Card>
  );
}
