import { useState } from 'react';
import { Link as RouterLink } from 'react-router-dom';
import { PaletteMode, styled, alpha } from '@mui/material/styles';
import Box from '@mui/material/Box';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Button from '@mui/material/Button';
import IconButton from '@mui/material/IconButton';
import Container from '@mui/material/Container';
import Divider from '@mui/material/Divider';
import MenuItem from '@mui/material/MenuItem';
import Drawer from '@mui/material/Drawer';
import MenuIcon from '@mui/icons-material/Menu';
import CloseRoundedIcon from '@mui/icons-material/CloseRounded';
import ToggleColorMode from '../toggleColorMode/ToggleColorMode';
import SignedInMenu from '../../layouts/SignedInMenu';
import { useAppSelector } from '../../store/configureStore';

const StyledToolbar = styled(Toolbar)(({ theme }) => ({
  display: 'flex',
  alignItems: 'center',
  justifyContent: 'space-between',
  flexShrink: 0,
  borderRadius: `calc(${theme.shape.borderRadius}px + 8px)`,
  backdropFilter: 'blur(24px)',
  border: '1px solid',
  borderColor: theme.palette.divider,
  backgroundColor: alpha(theme.palette.background.default, 0.4),
  boxShadow: theme.shadows[1],
  padding: '8px 12px',
}));

interface HeaderProps {
  mode: PaletteMode;
  toggleColorMode: () => void;
}

export default function Header({ mode, toggleColorMode }: HeaderProps) {
  const { user } = useAppSelector((state) => state.account);
  const [open, setOpen] = useState(false);

  const toggleDrawer = (newOpen: boolean) => () => {
    setOpen(newOpen);
  };

  return (
    <AppBar
      position='fixed'
      sx={{
        boxShadow: 0,
        bgcolor: 'transparent',
        backgroundImage: 'none',
        mt: 10,
      }}
    >
      <Container maxWidth='lg'>
        <StyledToolbar variant='dense' disableGutters>
          <Box
            sx={{ flexGrow: 1, display: 'flex', alignItems: 'center', px: 0 }}
          >
            <Box sx={{ display: { xs: 'none', md: 'flex' } }}>
              <Button
                component={RouterLink}
                to='/'
                variant='text'
                color='info'
                size='small'
              >
                Home
              </Button>
              <Button variant='text' color='info' size='small'>
                Features
              </Button>
              <Button variant='text' color='info' size='small'>
                Highlights
              </Button>
              <Button
                variant='text'
                color='info'
                size='small'
                sx={{ minWidth: 0 }}
              >
                FAQ
              </Button>
              <Button
                variant='text'
                component={RouterLink}
                to='request'
                color='info'
                size='small'
                sx={{ minWidth: 0 }}
              >
                Request
              </Button>
            </Box>
          </Box>
          <Box
            sx={{
              display: { xs: 'none', md: 'flex' },
              gap: 1,
              alignItems: 'center',
            }}
          >
            {user ? (
              <SignedInMenu />
            ) : (
              <>
                <Button
                  color='primary'
                  variant='text'
                  component={RouterLink}
                  to='login'
                  size='small'
                >
                  Sign in
                </Button>
                <Button
                  color='primary'
                  variant='contained'
                  component={RouterLink}
                  to='register'
                  size='small'
                >
                  Sign up
                </Button>
              </>
            )}

            <ToggleColorMode
              data-screenshot='toggle-mode'
              mode={mode}
              toggleColorMode={toggleColorMode}
            />
          </Box>
          <Box sx={{ display: { sm: 'flex', md: 'none' } }}>
            <IconButton aria-label='Menu button' onClick={toggleDrawer(true)}>
              <MenuIcon />
            </IconButton>
            <Drawer anchor='top' open={open} onClose={toggleDrawer(false)}>
              <Box sx={{ p: 2, backgroundColor: 'background.default' }}>
                <Box
                  sx={{
                    display: 'flex',
                    alignItems: 'center',
                    justifyContent: 'space-between',
                  }}
                >
                  <IconButton onClick={toggleDrawer(false)}>
                    <CloseRoundedIcon />
                  </IconButton>
                </Box>
                <Divider sx={{ my: 3 }} />
                <MenuItem>Features</MenuItem>
                <MenuItem>Highlights</MenuItem>
                <MenuItem>FAQ</MenuItem>
                <MenuItem>Request</MenuItem>
                <MenuItem>
                  <Button color='primary' variant='contained' fullWidth>
                    Sign up
                  </Button>
                </MenuItem>
                <MenuItem>
                  <Button color='primary' variant='outlined' fullWidth>
                    Sign in
                  </Button>
                </MenuItem>
              </Box>
            </Drawer>
          </Box>
        </StyledToolbar>
      </Container>
    </AppBar>
  );
}
