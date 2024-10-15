import { createTheme } from '@mui/material/styles';

declare module '@mui/material/styles' {
  interface PalletColor {
    900?: string;
    800?: string;
    700?: string;
    600?: string;
    500?: string;
    400?: string;
    300?: string;
    200?: string;
    100?: string;
    50?: string;
  }

  interface SimplePalletColorOptions {
    900?: string;
    800?: string;
    700?: string;
    600?: string;
    500?: string;
    400?: string;
    300?: string;
    200?: string;
    100?: string;
    50?: string;
  }
}

export const theme = createTheme({
  colorSchemes: {
    light: {
      palette: {
        primary: {
          900: '#12235a',
          800: '#22346d',
          700: '#293d79',
          600: '#314684',
          500: '#374e8d',
          main: '#55679c',
          300: '#7281ac',
          200: '#99a4c4',
          100: '#c1c8dc',
          50: '#e6e9f0',
        },
        secondary: {
          900: '#1c3d47',
          800: '#2d525f',
          700: '#3a6674',
          600: '#497b8a',
          main: '#558a9c',
          400: '#6e9cac',
          300: '#86afbe',
          200: '#a5c7d3',
          100: '#c3dfe8',
          50: '#dff3fd',
        },
        info: {
          900: '#38235f',
          800: '#4f2f6f',
          700: '#5d347a',
          600: '#6d3b84',
          500: '#78408b',
          main: '#8a559c',
          300: '#9e6fad',
          200: '#b996c5',
          100: '#d4bfdc',
          50: '#ede5f0',
        },
      },
    },
  },
});
