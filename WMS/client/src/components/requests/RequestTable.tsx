import { useState, useMemo, useEffect } from 'react';
import Paper from '@mui/material/Paper';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
//import TablePagination from '@mui/material/TablePagination';
import TableRow from '@mui/material/TableRow';
import { useAppSelector } from '../../store/configureStore';
import { Request } from '../../models/request';
import LoadingComponent from '../loading/LoadingComponent';
import RequestTableHead from './RequestTableHead';
import RequestTableToolbar from './RequestTableToolbar';
import { Box, Checkbox, TablePagination } from '@mui/material';
import { getComparator, Order } from '../../helpers/utils/Comparators';
//import { MetaData } from '../../models/pagination';
//import AppPagination from '../pagination/AppPagination';
//import { setPageNumber } from '../../pages/request/requestSlice';

interface Props {
  requests: Request[];
}

export default function RequestTable({ requests }: Props) {
  //const { currentPage = 1, totalCount = 4, pageSize = 10 } = metaData || {};
  const [order, setOrder] = useState<Order>('asc');
  const [orderBy, setOrderBy] = useState<keyof Request>('requestTitle');
  const [selected, setSelected] = useState<number[]>([]);
  const [selectedRequest, setSelectedRequest] = useState<number | null>(null);
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(5);
  const { requestsLoaded } = useAppSelector((state) => state.request);
  //const dispatch = useAppDispatch();

  useEffect(() => {
    setOrder('asc');
    setOrderBy('requestTitle');
  }, [setOrder, setOrderBy]);

  useEffect(() => {
    if (selected.length === 1) {
      setSelectedRequest(selected[0]);
    } else {
      setSelectedRequest(null);
    }
  }, [selected]);

  //   const handleRequestSort = (
  //     event: React.MouseEvent<unknown>,
  //     property: keyof Request
  //   ) => {
  //     const isAsc = orderBy === property.toString() && order === 'asc';
  //     setOrder(isAsc ? 'desc' : 'asc');
  //     setOrderBy(property);
  //   };

  const handleSelectAllClick = (event: React.ChangeEvent<HTMLInputElement>) => {
    if (event.target.checked) {
      const newSelected = requests.map((n) => n.requestId);
      setSelected(newSelected);
      return;
    }
    setSelected([]);
  };

  const handleClick = (id: number) => {
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
    setSelected(newSelected);
  };

  const handleChangePage = (event: unknown, newPage: number) => {
    setPage(newPage);
    //dispatch(setPageNumber({ pageNumber: newPage }));
  };

  const handleChangeRowsPerPage = (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };

  // Avoid a layout jump when reaching the last page with empty rows.
  const emptyRows =
    page > 0 ? Math.max(0, (1 + page) * rowsPerPage - requests.length) : 0;

  const visibleRows = useMemo(
    () =>
      [...requests]
        .sort(getComparator(order, orderBy))
        .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage),
    [order, orderBy, page, rowsPerPage, requests]
  );

  if (!requestsLoaded)
    return <LoadingComponent message='Loading requests...' />;

  return (
    <Box sx={{ width: '100%' }}>
      <Paper sx={{ width: '100%', mb: 2 }}>
        <RequestTableToolbar
          numSelected={selected.length}
          requestID={selectedRequest!}
        />
        <TableContainer sx={{ maxHeight: 440 }}>
          <Table stickyHeader aria-labelledby='tableTitle'>
            <RequestTableHead
              numSelected={selected.length}
              order='asc'
              orderBy='requestTitle'
              onSelectAllClick={handleSelectAllClick}
              rowCount={requests.length}
            />
            <TableBody>
              {visibleRows.map((request, index) => {
                const isItemSelected = selected.includes(request.requestId);
                const labelId = `request-table-checkbox-${index}`;

                return (
                  <TableRow
                    hover
                    onClick={() => handleClick(request.requestId)}
                    role='checkbox'
                    aria-checked={isItemSelected}
                    tabIndex={-1}
                    key={request.requestId}
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
                      {request.requestTitle}
                    </TableCell>
                    {/* <TableCell align='center'>{request.priority}</TableCell> */}
                    <TableCell align='left'>
                      {request.requestTypeName}
                    </TableCell>
                    <TableCell align='left'>
                      {request.requestorUsername}
                    </TableCell>
                    <TableCell align='left'>
                      {request.approvalStatusName}
                    </TableCell>
                    <TableCell align='left'>{request.createDate}</TableCell>
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
          count={requests.length}
          rowsPerPage={rowsPerPage}
          page={page}
          onPageChange={handleChangePage}
          onRowsPerPageChange={handleChangeRowsPerPage}
        />
      </Paper>
    </Box>
  );
}
