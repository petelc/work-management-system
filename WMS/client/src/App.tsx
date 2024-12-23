import { useState, useMemo, useEffect, useCallback } from 'react';
import { AppProvider } from '@toolpad/core/react-router-dom';
import { Outlet } from 'react-router-dom';
import type { Navigation, Session } from '@toolpad/core';
import { Cyclone, Dashboard, EditRoad, HowToReg } from '@mui/icons-material';

import { useAppDispatch, useAppSelector } from './store/hooks';
import { signOut, fetchCurrentUser } from './pages/account/accountSlice';

const NAVIGATION: Navigation = [
  {
    title: 'Dashboard',
    icon: <Dashboard />,
  },
  {
    kind: 'divider',
  },
  {
    segment: 'request',
    title: 'Submit Request',
    icon: <HowToReg />,
  },
  {
    kind: 'divider',
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
    segment: 'board',
    title: 'Board',
    icon: <EditRoad />,
  },
];

const BRANDING = {
  title: 'Work Management System',
};

export default function App() {
  const { user } = useAppSelector((state) => state.account);
  const dispatch = useAppDispatch();
  const [loading, setLoading] = useState(false);
  //const navigate = useNavigate();

  const initApp = useCallback(async () => {
    try {
      dispatch(fetchCurrentUser());
    } catch (error) {
      console.log(error);
    }
  }, [dispatch]);

  useEffect(() => {
    initApp().then(() => setLoading(false));
  }, [initApp]);

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
