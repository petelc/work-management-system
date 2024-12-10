import { Box, Typography, TablePagination } from '@mui/material';
import { MetaData } from '../../models/pagination';
import { useState } from 'react';

interface Props {
  metaData: MetaData;
  onPageChange: (page: number) => void;
  //onRowsPerPageChange: (rowsPerPage: number) => void;
}

export default function AppPagination({ metaData, onPageChange }: Props) {
  const { pageSize, currentPage, totalCount, totalPages } = metaData;
  const [pageNumber, setPageNumber] = useState(1);
  const [rowsPerPage, setRowsPerPage] = useState(10);

  setRowsPerPage(pageSize);

  function handlePageChange(page: number) {
    setPageNumber(page);
    onPageChange(page);
  }

  // const handleChangeRowsPerPage = (pageSize: number) => {
  //   setRowsPerPage(pageSize);
  //   setPageNumber(currentPage);
  // };

  return (
    <Box
      display='flex'
      justifyContent='space-between'
      alignItems='center'
      sx={{ marginBottom: 3 }}
    >
      <Typography variant='body1'>
        Displaying {(currentPage - 1) * pageSize + 1}-
        {currentPage * pageSize > totalCount!
          ? totalCount
          : currentPage * pageSize}{' '}
        of {totalCount} results
      </Typography>
      {/* <Pagination
        color='secondary'
        size='large'
        count={totalPages}
        page={pageNumber}
        onChange={(_e, page) => handlePageChange(page)}
      /> */}
      <TablePagination
        rowsPerPageOptions={[10, 25, 100]}
        component='div'
        count={totalPages}
        rowsPerPage={rowsPerPage}
        page={pageNumber}
        onPageChange={(_e, page) => handlePageChange(page)}
        // onRowsPerPageChange={(pageSize) =>
        //   handleChangeRowsPerPage(pageSize)
        // }
      />
    </Box>
  );
}
