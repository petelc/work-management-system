import { useEffect, cloneElement } from 'react';
//import { useNavigate } from 'react-router-dom';
import {
  Divider,
  styled,
  Typography,
  Grid2 as Grid,
  Stack,
  Box,
  TextField,
  Accordion,
  AccordionSummary,
  AccordionDetails,
  List,
  ListItem,
  IconButton,
  ListItemAvatar,
  Avatar,
  ListItemText,
  Checkbox,
  FormGroup,
  FormControlLabel,
  AccordionActions,
  Button,
} from '@mui/material';

import { useAppSelector, useAppDispatch } from '../../../store/hooks';
import {
  boardSelectors,
  fetchBoardAsync,
} from '../../../pages/board/boardSlice';
import LoadingComponent from '../../loading/LoadingComponent';
import {
  AddCircle,
  Approval,
  ApprovalOutlined,
  Cyclone,
  Feedback,
  ForumRounded,
  Hub,
  ThumbDownAlt,
  ThumbDownAltOutlined,
} from '@mui/icons-material';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import FolderIcon from '@mui/icons-material/Folder';
import DownloadIcon from '@mui/icons-material/Download';
//import { Board } from '../../../models/board';

interface Props {
  selected: number;
}

// const Root = styled('div')(({ theme }) => ({
//   height: '100%',
//   backgroundColor: grey[100],
//   ...theme.applyStyles('dark', {
//     backgroundColor: theme.palette.background.default,
//   }),
// }));

const StyledBox = styled('div')(({ theme }) => ({
  backgroundColor: '#fff',
  ...theme.applyStyles('dark', {
    backgroundColor: theme.palette.background.paper,
  }),
}));

function generate(element: React.ReactElement<unknown>) {
  return [0, 1, 2].map((value) =>
    cloneElement(element, {
      key: value,
    })
  );
}

export default function DrawerContent({ selected }: Props) {
  //const [dense, setDense] = useState(true);
  //const [secondary, setSecondary] = useState(false);
  const dispatch = useAppDispatch();
  const board = useAppSelector((state) =>
    boardSelectors.selectById(state, selected!)
  );
  const { status } = useAppSelector((state) => state.board);
  const secondary = 'false';

  useEffect(() => {
    if (!board && selected) {
      dispatch(fetchBoardAsync(selected));
    }
  }, [board, selected, dispatch]);

  const { requestName, createDate } = board || {};

  if (status === 'pending')
    return <LoadingComponent message='Loading board...' />;

  return (
    <>
      <StyledBox
        role='presentation'
        sx={{ width: 600, px: 2, pb: 2, height: '100%', overflow: 'auto' }}
      >
        <Typography variant='h6' sx={{ paddingTop: 10, paddingBottom: 2 }}>
          Request Review
        </Typography>
        <Divider />
        <Box sx={{ '& > :not(style)': { m: 1 } }}>
          <Grid container spacing={4} sx={{ padding: 2 }}>
            <Grid size={12}>
              <Stack
                direction='row'
                spacing={2}
                sx={{ justifyContent: 'space-between' }}
              >
                <Hub />
                <Typography variant='subtitle1'>
                  {new Date(createDate).toLocaleDateString()}
                </Typography>
              </Stack>
            </Grid>
            <Grid size={12}>
              <Typography
                variant='subtitle1'
                id='requestName'
                sx={{ width: '35ch' }}
              >
                {requestName}
              </Typography>
            </Grid>
            <Grid size={12}>
              <Stack direction='row' spacing={4}>
                <TextField
                  id='requestor'
                  aria-readonly='true'
                  value={board?.request?.requestor?.displayName}
                  variant='filled'
                  defaultValue=''
                  helperText='Requestor'
                />
                <TextField
                  id='requestType'
                  aria-readonly='true'
                  value={board?.request?.requestType?.requestTypeName}
                  variant='filled'
                  defaultValue=''
                  helperText='Request Type'
                />
              </Stack>
            </Grid>
            <Grid size={12}>
              <Stack direction='row' spacing={4}>
                <TextField
                  id='priority'
                  aria-readonly='true'
                  value={board?.request?.priority}
                  variant='filled'
                  defaultValue=''
                  helperText='Priority'
                />
                <TextField
                  id='approvalStatus'
                  aria-readonly='true'
                  value={board?.request?.approvalStatus?.approvalStatusName}
                  variant='filled'
                  defaultValue=''
                  helperText='Approval Status'
                />
              </Stack>
            </Grid>
            <Grid size={12}>
              <TextField
                id='description'
                multiline
                fullWidth
                aria-readonly='true'
                value={board?.request?.description}
                variant='filled'
                defaultValue=''
                helperText='Description'
              />
            </Grid>
            <Grid size={12}>
              <Accordion>
                <AccordionSummary
                  expandIcon={<ExpandMoreIcon />}
                  aria-controls='panel2-content'
                  id='panel2-header'
                >
                  <Typography component='span'>Documentation</Typography>
                </AccordionSummary>
                <AccordionDetails>
                  <List dense={false}>
                    {generate(
                      <ListItem
                        secondaryAction={
                          <IconButton edge='end' aria-label='delete'>
                            <DownloadIcon />
                          </IconButton>
                        }
                      >
                        <ListItemAvatar>
                          <Avatar>
                            <FolderIcon />
                          </Avatar>
                        </ListItemAvatar>
                        <ListItemText
                          primary='Single-line item'
                          secondary={secondary ? 'Secondary text' : null}
                        />
                      </ListItem>
                    )}
                  </List>
                </AccordionDetails>
              </Accordion>
            </Grid>
          </Grid>
          <Divider />
          <Grid container spacing={4} sx={{ padding: 2 }}>
            <Grid size={12}>
              <Stack direction='row' spacing={4}>
                <ForumRounded />
                <Typography variant='subtitle1'>Board Approval</Typography>
              </Stack>
            </Grid>
            <Grid size={12}>
              <Stack
                direction='row'
                spacing={4}
                sx={{ alignItems: 'center', justifyContent: 'space-between' }}
              >
                Approve?
                <Stack
                  direction='row'
                  spacing={2}
                  sx={{ alignItems: 'center', justifyContent: 'space-between' }}
                >
                  <FormGroup>
                    <FormControlLabel
                      control={
                        <Checkbox
                          icon={<ApprovalOutlined />}
                          checkedIcon={<Approval />}
                        />
                      }
                      label='Approve'
                    />
                  </FormGroup>
                  <FormGroup>
                    <FormControlLabel
                      control={
                        <Checkbox
                          icon={<ThumbDownAltOutlined />}
                          checkedIcon={<ThumbDownAlt />}
                        />
                      }
                      label='Deny'
                    />
                  </FormGroup>
                </Stack>
              </Stack>
              <Divider sx={{ paddingTop: 2, paddingBottom: 2 }} />
            </Grid>
            <Grid size={12}>
              <Stack direction='row' spacing={4}>
                <Feedback />
                <Typography variant='subtitle1'>Comments</Typography>
              </Stack>
            </Grid>
            <Grid size={12}>
              {/* 
                // TODO Build the comment component
                // TODO Loop over added comments  
              */}
              <Accordion>
                <AccordionSummary
                  expandIcon={<AddCircle />}
                  aria-controls='panel2-content'
                  id='panel2-header'
                >
                  <Typography component='span'>Add a Comment</Typography>
                </AccordionSummary>
                <AccordionDetails>
                  <TextField
                    id='comment'
                    multiline
                    fullWidth
                    aria-readonly='true'
                    variant='filled'
                    defaultValue=''
                    helperText='Add a comment'
                  />
                </AccordionDetails>
                <AccordionActions>
                  <Button>Save</Button>
                  <Button>Cancel</Button>
                </AccordionActions>
              </Accordion>
            </Grid>
            <Grid size={12}>
              <Stack direction='row' spacing={4}>
                <Cyclone />
                <Typography variant='subtitle1'>History</Typography>
              </Stack>
            </Grid>
          </Grid>
        </Box>
      </StyledBox>
    </>
  );
}
