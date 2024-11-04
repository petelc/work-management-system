import { alpha, Box, Stack } from '@mui/material';
import SideMenu from '../../components/sidemenu/SideMenu';
import AppNavBar from '../../components/appnavbar/AppNavBar';
import Dheader from '../../components/dheader/Dheader';
import MainGrid from '../../components/maingrid/MainGrid';

export default function Dashboard() {
  return (
    <Box sx={{ display: 'flex' }}>
      <SideMenu />
      <AppNavBar />
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
          <Dheader />
          <MainGrid />
        </Stack>
      </Box>
    </Box>
  );
}
