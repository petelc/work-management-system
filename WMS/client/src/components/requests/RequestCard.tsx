import {
  Button,
  Card,
  CardActions,
  CardContent,
  Typography,
} from '@mui/material';
import { Link } from 'react-router-dom';
import { LoadingButton } from '@mui/lab';

import { Request } from '../../models/request';
//import { useAppDispatch, useAppSelector } from '../../store/configureStore';

interface Props {
  request: Request;
  requestTypeName?: string;
}

export default function RequestCard({ request }: Props) {
  const { requestTitle, description } = request;
  console.log(requestTitle, description);

  return (
    <Card>
      <CardContent sx={{ p: 2 }}>
        <Typography
          variant='h4'
          color='primary'
          sx={{ mb: 4, textAlign: 'center' }}
        >
          {requestTitle}
        </Typography>
        <Typography variant='h6' color='text.light' sx={{ mb: 4 }}>
          {description}
        </Typography>
        <Typography
          gutterBottom
          color='text.secondary'
          variant='body2'
          component='div'
        >
          Is this approved
        </Typography>
        <Typography variant='body2' color='text.secondary'>
          / Your Requests status
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
