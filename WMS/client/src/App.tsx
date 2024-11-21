import { useState, useMemo, useEffect } from 'react';
import { AppProvider } from '@toolpad/core/react-router-dom';
import { Outlet } from 'react-router-dom';
import type { Navigation, Session } from '@toolpad/core';
import { Cyclone, Dashboard, HowToReg } from '@mui/icons-material';

import { useAppDispatch, useAppSelector } from './store/configureStore';
import { signOut } from './pages/account/accountSlice';
import getMPTheme from './styles/theme/getMPTheme';
import { createTheme, PaletteMode } from '@mui/material/styles';

/**
 * NOTE: What components are needed?
 * //TODO - AccountSidebarPreview
 * //TODO - SidebarFooterAccountPopover
 * //TODO - SidebarFooterAccount
 *
 * NOTE: Function needed
 * //TODO - createPreviewComponent
 *
 * NOTE: I need a session capability. There is the get current user in the redux store.
 * NOTE: I also need the Signin component
 */

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
  const [mode, setMode] = useState<PaletteMode>('dark');

  const MPTheme = createTheme(getMPTheme(mode));

  useEffect(() => {
    const savedMode = localStorage.getItem('themeMode') as PaletteMode | null;
    if (savedMode) {
      setMode(savedMode);
    } else {
      const systemPrefersDark = window.matchMedia(
        '(prefers-color-scheme: dark)'
      ).matches;
      setMode(systemPrefersDark ? 'dark' : 'light');
    }
  }, []);

  // const toggleColorMode = () => {
  //   const newMode = mode === 'dark' ? 'light' : 'dark';
  //   setMode(newMode);
  //   localStorage.setItem('themeMode', newMode); // Save the selected mode to localStorage
  // };

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
      theme={MPTheme}
      navigation={NAVIGATION}
      branding={BRANDING}
      session={session}
      authentication={authentication}
    >
      <Outlet />
    </AppProvider>
  );
}
