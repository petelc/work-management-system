import { Cyclone, Hub } from '@mui/icons-material';
import { Button, Stack } from '@mui/material';
import { PageContainerToolbar } from '@toolpad/core';

export function PageToolbar() {
  return (
    <PageContainerToolbar>
      <Stack direction='row' spacing={1} alignItems='center'>
        <Button
          variant='outlined'
          size='small'
          startIcon={<Hub fontSize='inherit' />}
        >
          CAB Board
        </Button>
        <Button
          variant='outlined'
          size='small'
          startIcon={<Cyclone fontSize='inherit' />}
        >
          Incidental
        </Button>
      </Stack>
    </PageContainerToolbar>
  );
}
