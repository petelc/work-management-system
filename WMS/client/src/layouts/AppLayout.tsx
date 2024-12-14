import { useState, useEffect } from 'react';
import { Outlet, useLocation } from 'react-router-dom';
import { PaletteMode, ThemeProvider, createTheme } from '@mui/material/styles';
import CssBaseline from '@mui/material/CssBaseline';
import { alpha, Box, Stack } from '@mui/material';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

import getLPTheme from '../styles/theme/getLPTheme';
import SideMenu from '../components/sidemenu/SideMenu';
import AppNaveBar from '../components/appnavbar/AppNavBar';
import AppHeader from '../components/appheader/AppHeader';
import LoadingComponent from '../components/loading/LoadingComponent';
import Dashboard from './Dashboard';

function AppLayout() {
  const location = useLocation();

  const [loading, setLoading] = useState(false);
  const [mode, setMode] = useState<PaletteMode>('dark');

  const LPTheme = createTheme(getLPTheme(mode));

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

  const toggleColorMode = () => {
    const newMode = mode === 'dark' ? 'light' : 'dark';
    setMode(newMode);
    localStorage.setItem('themeMode', newMode); // Save the selected mode to localStorage
  };

  if (loading) setLoading(true);

  return (
    <ThemeProvider theme={LPTheme}>
      <ToastContainer position='bottom-right' hideProgressBar theme='colored' />
      <CssBaseline enableColorScheme />
      <Box sx={{ display: 'flex' }}>
        <SideMenu />
        <AppNaveBar />
        <Box
          component='main'
          sx={(theme) => ({
            flexGrow: 1,
            backgroundColor: theme.vars
              ? `rgba(${theme.vars.palette.background.defaultChannel} / 1)`
              : alpha(theme.palette.background.default, 1),
            overflow: 'auto',
          })}
        >
          <Stack
            spacing={2}
            sx={{
              alignItems: 'center',
              mx: 3,
              pb: 5,
              mt: { xs: 8, md: 0 },
            }}
          >
            <AppHeader mode={mode} toggleColorMode={toggleColorMode} />
            {loading ? (
              <LoadingComponent message='Initializing app ...' />
            ) : location.pathname === '/dashboard' ? (
              <Dashboard />
            ) : (
              <Outlet />
            )}
          </Stack>
        </Box>
      </Box>
    </ThemeProvider>
  );
}

export default AppLayout;
