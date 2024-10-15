import { useState } from 'react';
import { Button, Menu, Fade, MenuItem } from '@mui/material';
import { Link } from 'react-router-dom';

export default function SignedInMenu() {
  const [anchorEl, setAnchorEl] = useState(null);
  const open = Boolean(anchorEl);

  const handleClick = (event: any) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  return (
    <>
      <Button color='inherit' onClick={handleClick} sx={{ typography: 'h6' }}>
        Email
      </Button>
      <Menu
        anchorEl={anchorEl}
        open={open}
        onClose={handleClose}
        TransitionComponent={Fade}
      >
        <MenuItem onClick={handleClose}>Profile</MenuItem>
        <MenuItem component={Link} to='/requests'>
          My Requests
        </MenuItem>
        <MenuItem>Logout</MenuItem>
      </Menu>
    </>
  );
}
