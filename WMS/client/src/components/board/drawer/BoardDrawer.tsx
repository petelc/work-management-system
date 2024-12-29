import { SwipeableDrawer } from '@mui/material';
import { Fragment } from 'react';
import DrawerContent from './DrawerContent';
//import { Board } from '../../../models/board';

//type Anchor = 'right';

interface Props {
  state: { right: boolean };
  selected: number;
  toggleDrawer: (
    anchor: 'right',
    open: boolean,
    id: number
  ) => (event: React.KeyboardEvent | React.MouseEvent) => void;
}

export default function BoardDrawer({ state, selected, toggleDrawer }: Props) {
  return (
    <div>
      <Fragment>
        <SwipeableDrawer
          anchor='right'
          open={state['right']}
          onClose={toggleDrawer('right', false, 0)}
          onOpen={toggleDrawer('right', true, 0)}
        >
          <DrawerContent selected={selected} />
        </SwipeableDrawer>
      </Fragment>
    </div>
  );
}
