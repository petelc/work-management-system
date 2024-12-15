import { useEffect } from 'react';
import { styled } from '@mui/material/styles';
import Avatar from '@mui/material/Avatar';
import MuiDrawer, { drawerClasses } from '@mui/material/Drawer';
import Box from '@mui/material/Box';
import Divider from '@mui/material/Divider';
import Stack from '@mui/material/Stack';
import Typography from '@mui/material/Typography';
import { Person } from '@mui/icons-material';
import MenuContent from '../menucontent/MenuContent';
import SelectContent from '../selectcontent/SelectContent';
import CardAlert from '../cardalert/CardAlert';
import OptionsMenu from '../optionsmenu/OptionsMenu';
import { useAppDispatch, useAppSelector } from '../../store/hooks';
import { fetchCurrentUser } from '../../pages/account/accountSlice';

//import MenuContent from './MenuContent';
//import CardAlert from './CardAlert';
//import OptionsMenu from './OptionsMenu';

const drawerWidth = 240;

const Drawer = styled(MuiDrawer)({
  width: drawerWidth,
  flexShrink: 0,
  boxSizing: 'border-box',
  mt: 10,
  [`& .${drawerClasses.paper}`]: {
    width: drawerWidth,
    boxSizing: 'border-box',
  },
});

export default function SideMenu() {
  const { user } = useAppSelector((state) => state.account);
  const dispatch = useAppDispatch();

  useEffect(() => {
    if (!user) dispatch(fetchCurrentUser());
  }, [user, dispatch]);

  console.log('SideMenu ', user);

  return (
    <Drawer
      variant='permanent'
      sx={{
        display: { xs: 'none', md: 'block' },
        [`& .${drawerClasses.paper}`]: {
          backgroundColor: 'background.paper',
        },
      }}
    >
      <Box
        sx={{
          display: 'flex',
          mt: 'calc(var(--template-frame-height, 0px) + 4px)',
          p: 1.5,
        }}
      >
        <SelectContent />
      </Box>
      <Divider />
      <MenuContent />
      <CardAlert />
      <Stack
        direction='row'
        sx={{
          p: 2,
          gap: 1,
          alignItems: 'center',
          borderTop: '1px solid',
          borderColor: 'divider',
        }}
      >
        <Avatar sizes='small' alt='Pete Carroll' sx={{ width: 36, height: 36 }}>
          {<Person />}
        </Avatar>
        <Box sx={{ mr: 'auto' }}>
          <Typography
            variant='body2'
            sx={{ fontWeight: 500, lineHeight: '16px' }}
          >
            {user?.displayName} {/* TODO - get current users information */}
          </Typography>
          <Typography variant='caption' sx={{ color: 'text.secondary' }}>
            {user?.email} {/* TODO - get current users information */}
          </Typography>
        </Box>
        <OptionsMenu />
      </Stack>
    </Drawer>
  );
}
