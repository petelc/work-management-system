import Stack from '@mui/material/Stack';
import NotificationsRoundedIcon from '@mui/icons-material/NotificationsRounded';
import { PaletteMode } from '@mui/material/styles';
import ToggleColorMode from '../toggleColorMode/ToggleColorMode';
import CustomDatePicker from '../customdatepicker/CustomDatePicker';
import NavbarBreadcrumbs from '../navbreadcrumbs/NavBreadCrumbs';
import MenuButton from '../menubutton/MenuButton';
import Search from '../search/Search';

interface AppHeaderProps {
  mode: PaletteMode;
  toggleColorMode: () => void;
}

export default function AppHeader({ mode, toggleColorMode }: AppHeaderProps) {
  return (
    <Stack
      direction='row'
      sx={{
        display: { xs: 'none', md: 'flex' },
        width: '100%',
        alignItems: { xs: 'flex-start', md: 'center' },
        justifyContent: 'space-between',
        maxWidth: { sm: '100%', md: '1700px' },
        pt: 1.5,
      }}
      spacing={2}
    >
      <NavbarBreadcrumbs />
      <Stack direction='row' sx={{ gap: 1 }}>
        <Search />
        <CustomDatePicker />
        <MenuButton showBadge aria-label='Open notifications'>
          <NotificationsRoundedIcon />
        </MenuButton>
        <ToggleColorMode
          data-screenshot='toggle-mode'
          mode={mode}
          toggleColorMode={toggleColorMode}
        />
      </Stack>
    </Stack>
  );
}
