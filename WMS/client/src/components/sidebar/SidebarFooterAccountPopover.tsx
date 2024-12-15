import { useEffect } from 'react';
import {
  Avatar,
  Divider,
  ListItemIcon,
  ListItemText,
  MenuItem,
  MenuList,
  Stack,
  Typography,
} from '@mui/material';
import { AccountPopoverFooter, SignOutButton } from '@toolpad/core';
import { useAppDispatch, useAppSelector } from '../../store/hooks';
import { fetchCurrentUser } from '../../pages/account/accountSlice';

export default function SidebarFooterAccountPopover() {
  const { user } = useAppSelector((state) => state.account);
  const dispatch = useAppDispatch();

  useEffect(() => {
    if (!user) dispatch(fetchCurrentUser());
  }, [user, dispatch]);

  console.log('SidebarFooterAccountPopover ', user);

  return (
    <Stack direction='column'>
      <Typography variant='body2' mx={2} mt={1}>
        Account(s)
      </Typography>
      <MenuList>
        <MenuItem
          component='button'
          sx={{
            justifyContent: 'flex-start',
            width: '100%',
            columnGap: 2,
          }}
        >
          <ListItemIcon>
            <Avatar
              sx={{
                width: 32,
                height: 32,
                fontSize: '0.95rem',
                bgcolor: 'Background',
              }}
              src={''}
              alt={user?.username ?? ''}
            >
              Peter Carroll
            </Avatar>
          </ListItemIcon>
          <ListItemText
            sx={{
              display: 'flex',
              flexDirection: 'column',
              alignItems: 'flex-start',
              width: '100%',
            }}
            primary={user?.displayName}
            secondary={user?.email}
            primaryTypographyProps={{ variant: 'body2' }}
            secondaryTypographyProps={{ variant: 'caption' }}
          />
        </MenuItem>
      </MenuList>
      <Divider />
      <AccountPopoverFooter>
        <SignOutButton />
      </AccountPopoverFooter>
    </Stack>
  );
}
