import { useState, useEffect } from 'react';
import Paper from '@mui/material/Paper';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import { Box, Checkbox, TablePagination } from '@mui/material';
import TableRow from '@mui/material/TableRow';
import { useAppSelector } from '../../store/hooks';
import { Board } from '../../models/board';
import LoadingComponent from '../loading/LoadingComponent';
import BoardTableHead from './BoardTableHead';
import BoardTableToolbar from './BoardTableToolbar';
import BoardDrawer from './drawer/BoardDrawer';

interface Props {
  boards: Board[];
}

type Anchor = 'right';

export default function BoardTable({ boards }: Props) {
  const [selected, setSelected] = useState<number[]>([]);
  const [selectedRequest, setSelectedRequest] = useState<number | null>(null);
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(5);
  const [state, setState] = useState({ right: false });

  const { boardsLoaded } = useAppSelector((state) => state.board);

  useEffect(() => {
    if (selected.length === 1) {
      setSelectedRequest(selected[0]);
    } else {
      setSelectedRequest(null);
    }
  }, [selected]);

  // const handleSelectAllClick = (event: React.ChangeEvent<HTMLInputElement>) => {
  //   if (event.target.checked) {
  //     const newSelected = boards.map((n) => n.cabId);
  //     setSelected(newSelected);
  //     return;
  //   }
  //   setSelected([]);
  // };

  // const handleClick = (id: number) => {
  //   const selectedIndex = selected.indexOf(id);
  //   let newSelected: number[] = [];

  //   if (selectedIndex === -1) {
  //     newSelected = newSelected.concat(selected, id);
  //   } else if (selectedIndex === 0) {
  //     newSelected = newSelected.concat(selected.slice(1));
  //   } else if (selectedIndex === selected.length - 1) {
  //     newSelected = newSelected.concat(selected.slice(0, -1));
  //   } else if (selectedIndex > 0) {
  //     newSelected = newSelected.concat(
  //       selected.slice(0, selectedIndex),
  //       selected.slice(selectedIndex + 1)
  //     );
  //   }
  //   setSelected(newSelected);
  // };

  const handleChangePage = (
    event: React.MouseEvent<HTMLButtonElement> | null,
    newPage: number
  ) => {
    if (event) {
      event.preventDefault();
    }
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };

  const emptyRows =
    page > 0 ? Math.max(0, (1 + page) * rowsPerPage - boards.length) : 0;

  const visibleRows = boards.slice(
    page * rowsPerPage,
    page * rowsPerPage + rowsPerPage
  );

  if (!boardsLoaded) return <LoadingComponent message='Loading boards...' />;

  const toggleDrawer =
    (anchor: Anchor, open: boolean, id: number) =>
    (event: React.KeyboardEvent | React.MouseEvent) => {
      if (
        event &&
        event.type === 'keydown' &&
        ((event as React.KeyboardEvent).key === 'Tab' ||
          (event as React.KeyboardEvent).key === 'Shift')
      ) {
        return;
      }

      const selectedIndex = selected.indexOf(id);
      let newSelected: number[] = [];

      if (selectedIndex === -1) {
        newSelected = newSelected.concat(selected, id);
      } else if (selectedIndex === 0) {
        newSelected = newSelected.concat(selected.slice(1));
      } else if (selectedIndex === selected.length - 1) {
        newSelected = newSelected.concat(selected.slice(0, -1));
      } else if (selectedIndex > 0) {
        newSelected = newSelected.concat(
          selected.slice(0, selectedIndex),
          selected.slice(selectedIndex + 1)
        );
      }
      setState({ ...state, [anchor]: open });
      setSelected(newSelected);
    };

  return (
    <Box sx={{ width: '100%' }}>
      <Paper sx={{ width: '100%', mb: 2 }}>
        <BoardTableToolbar
          numSelected={selected.length}
          cabId={selectedRequest!}
        />
        <TableContainer sx={{ maxHeight: 440 }}>
          <Table stickyHeader aria-label='sticky table'>
            <BoardTableHead
              numSelected={0}
              onSelectAllClick={() => {}}
              order='asc'
              orderBy='requestTitle'
              rowCount={boards.length}
            />
            <TableBody>
              {visibleRows.map((board, index) => {
                const isItemSelected = selected.indexOf(board.cabId) !== -1;
                const labelId = `board-table-checkbox-${index}`;
                return (
                  <TableRow
                    hover
                    // onClick={() => handleClick(board.cabId)}
                    onClick={toggleDrawer('right', true, board.cabId)}
                    role='checkbox'
                    aria-checked={isItemSelected}
                    tabIndex={-1}
                    key={board.cabId}
                    selected={isItemSelected}
                    sx={{ cursor: 'pointer' }}
                  >
                    <TableCell padding='checkbox'>
                      <Checkbox
                        color='primary'
                        checked={isItemSelected}
                        inputProps={{ 'aria-labelledby': labelId }}
                      />
                    </TableCell>
                    <TableCell
                      component='th'
                      id={labelId}
                      scope='row'
                      padding='none'
                    >
                      {board.requestName}
                    </TableCell>
                    <TableCell>
                      {board.request?.requestType.requestTypeName}
                    </TableCell>
                    <TableCell>
                      {board.request?.requestor.displayName}
                    </TableCell>
                    <TableCell align='center'>{board.votes}</TableCell>
                    <TableCell align='left'>
                      {new Date(board.createDate).toLocaleDateString()}
                    </TableCell>
                  </TableRow>
                );
              })}
              {emptyRows > 0 && (
                <TableRow
                  style={{
                    height: 53 * emptyRows,
                  }}
                >
                  <TableCell colSpan={6} />
                </TableRow>
              )}
            </TableBody>
          </Table>
        </TableContainer>
        <TablePagination
          rowsPerPageOptions={[5, 10, 25, 100]}
          component='div'
          count={boards.length}
          rowsPerPage={rowsPerPage}
          page={page}
          onPageChange={handleChangePage}
          onRowsPerPageChange={handleChangeRowsPerPage}
        />
        <BoardDrawer
          toggleDrawer={toggleDrawer}
          state={state}
          selected={selectedRequest!}
        />
      </Paper>
    </Box>
  );
}
