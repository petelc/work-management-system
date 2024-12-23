import { useEffect, useState } from 'react';
import { Navigate, Outlet, useLocation } from 'react-router-dom';
import { useAppSelector, useAppDispatch } from '../../store/hooks';
import { toast } from 'react-toastify';
import { fetchCurrentUser } from '../../pages/account/accountSlice';

interface Props {
  roles?: string[];
}

// TODO: Implement roles
// TODO: I need to figure out how to get a logged in user after page refresh
// TODO: before the check for no user so it maintains the user state after refresh

export default function RequireAuth({ roles }: Props) {
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const { user } = useAppSelector((state) => state.account);
  const dispatch = useAppDispatch();

  const location = useLocation();

  useEffect(() => {
    if (!user) {
      dispatch(fetchCurrentUser());
      setIsAuthenticated(true);
    }
  }, [dispatch, user, setIsAuthenticated]);

  // if (!user && !isAuthenticated) {
  //   toast.error('You need to be logged in to do that!');
  //   return <Navigate to='/login' state={{ from: location }} />;
  // }

  // if (roles && !roles?.some((r) => user.roles?.includes(r))) {
  //   toast.error('Your role does not allow access to this area');
  //   return <Navigate to='/' />;
  // }

  return <Outlet />;
}
