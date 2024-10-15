import { useState, useEffect } from 'react';
//import { useLocation } from 'react-router-dom';
import { PaletteMode, ThemeProvider, createTheme } from '@mui/material/styles';
import CssBaseline from '@mui/material/CssBaseline';
import Divider from '@mui/material/Divider';
import getMPTheme from '../styles/theme/getMPTheme';
import Header from '../components/header/Header';
import Hero from '../components/hero/Hero';
import Features from '../components/features/Features';
import FAQ from '../components/faq/FAQ';
import Footer from '../components/footer/Footer';

function App() {
  //const location = useLocation();
  const [loading, setLoading] = useState(false);
  const [mode, setMode] = useState<PaletteMode>('light');

  const MPTheme = createTheme(getMPTheme(mode));
  //const defaultTheme = createTheme({ palette: { mode } });

  // This code only runs on the client side, to determine the system color preference
  useEffect(() => {
    // Check if there is a preferred mode in localStorage
    const savedMode = localStorage.getItem('themeMode') as PaletteMode | null;
    if (savedMode) {
      setMode(savedMode);
    } else {
      // If no preference is found, it uses system preference
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
      <CssBaseline enableColorScheme />
      <Header mode={mode} toggleColorMode={toggleColorMode} />
      <Hero />
      <div>
        <Features />
        <Divider />
        <FAQ />
        <Divider />
        <Footer />
      </div>
    </ThemeProvider>
  );
}

export default App;
