import { useState, useEffect, useCallback } from 'react';
import { Outlet, useLocation } from 'react-router-dom';
import { PaletteMode, ThemeProvider, createTheme } from '@mui/material/styles';
import CssBaseline from '@mui/material/CssBaseline';
import Container from '@mui/material/Container';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import getMPTheme from '../styles/theme/getMPTheme';
import Header from '../components/header/Header';
import LoadingComponent from '../components/loading/LoadingComponent';
import HomePage from '../pages/home/HomePage';
import { useAppDispatch } from '../store/configureStore';
import { fetchCurrentUser } from '../pages/account/accountSlice';

function App() {
  const location = useLocation();
  const dispatch = useAppDispatch();
  const [loading, setLoading] = useState(false);
  const [mode, setMode] = useState<PaletteMode>('light');

  const MPTheme = createTheme(getMPTheme(mode));

  const initApp = useCallback(async () => {
    try {
      await dispatch(fetchCurrentUser());
    } catch (error) {
      console.log(error);
    }
  }, [dispatch]);

  useEffect(() => {
    initApp().then(() => setLoading(false));
  }, [initApp]);

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
    <ThemeProvider theme={MPTheme}>
      <ToastContainer position='bottom-right' hideProgressBar theme='colored' />
      <CssBaseline enableColorScheme />
      <Header mode={mode} toggleColorMode={toggleColorMode} />
      {loading ? (
        <LoadingComponent message='Initializing app ...' />
      ) : location.pathname === '/' ? (
        <HomePage />
      ) : (
        <Container sx={{ mt: 4 }}>
          <Outlet />
        </Container>
      )}
    </ThemeProvider>
  );
}

export default App;
