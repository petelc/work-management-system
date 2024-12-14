import { useState, useMemo, useEffect } from 'react';
import { AppProvider } from '@toolpad/core/react-router-dom';
import { Outlet, useNavigate } from 'react-router-dom';
import type { Navigation, Session } from '@toolpad/core';
import { Cyclone, Dashboard, HowToReg } from '@mui/icons-material';

import { useAppDispatch, useAppSelector } from './store/hooks';
import { signOut } from './pages/account/accountSlice';

const NAVIGATION: Navigation = [
  {
    title: 'Dashboard',
    icon: <Dashboard />,
  },
  {
    segment: 'requests',
    title: 'Requests',
    icon: <Cyclone />,
  },
  {
    kind: 'divider',
  },
  {
    segment: 'request',
    title: 'Submit Request',
    icon: <HowToReg />,
  },
];

const BRANDING = {
  title: 'Work Management System',
};

export default function App() {
  const { user } = useAppSelector((state) => state.account);
  const dispatch = useAppDispatch();
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();

  useEffect(() => {
    const token = localStorage.getItem('user');
    if (token) {
      setSession({
        user: {
          name: user?.displayName,
          email: user?.email,
          image: '',
        },
      });
    } else {
      navigate('/login');
    }
  }, [navigate]);

  const [session, setSession] = useState<Session | null>({
    user: {
      name: user?.displayName,
      email: user?.email,
      image: '',
    },
  });

  const authentication = useMemo(() => {
    return {
      signIn: () => {
        setSession({
          user: {
            name: user?.displayName,
            email: user?.email,
            image: '',
          },
        });
      },
      signOut: () => {
        dispatch(signOut());
        setSession(null);
      },
    };
  }, [user, dispatch]);

  if (loading) setLoading(true);

  return (
    <AppProvider
      navigation={NAVIGATION}
      branding={BRANDING}
      session={session}
      authentication={authentication}
    >
      <Outlet />
    </AppProvider>
  );
}
