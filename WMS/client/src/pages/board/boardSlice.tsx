/* eslint-disable @typescript-eslint/no-unused-expressions */
import {
  createAsyncThunk,
  createEntityAdapter,
  createSlice,
} from '@reduxjs/toolkit';
import agent from '../../api/agent';
import { RootState } from '../../store/configureStore';
import { Board, BoardParams } from '../../models/board';
import { MetaData } from '../../models/pagination';

interface BoardState {
  boardsLoaded: boolean;
  filtersLoaded: boolean;
  status: string;
  boardParams: BoardParams;
  metaData: MetaData | null;
}

const boardAdapter = createEntityAdapter({
  selectId: (e: any) => e.cabId,
});

function getAxiosParams(boardParams: BoardParams) {
  const params = new URLSearchParams();
  params.append('pageNumber', boardParams.pageNumber.toString());
  params.append('pageSize', boardParams.pageSize.toString());
  params.append('orderBy', boardParams.orderBy);
  if (boardParams.searchTerm)
    params.append('searchTerm', boardParams.searchTerm);

  return params;
}

// NOTE: Fetch all submitted boards
export const fetchBoardsAsync = createAsyncThunk<
  Board[],
  void,
  { state: RootState }
>('board/fetchBoardsAsync', async (_, thunkAPI) => {
  const params = getAxiosParams(thunkAPI.getState().board.boardParams);
  try {
    const response = await agent.CABRequest.list(params);
    thunkAPI.dispatch(setMetaData(response.MetaData));
    return response.items;
  } catch (error: any) {
    return thunkAPI.rejectWithValue({ error: error.data });
  }
});

function initParams(): BoardParams {
  return {
    orderBy: 'createDate desc',
    pageNumber: 1,
    pageSize: 10,
  };
}

export const boardSlice = createSlice({
  name: 'board',
  initialState: boardAdapter.getInitialState<BoardState>({
    boardsLoaded: false,
    filtersLoaded: false,
    status: 'idle',
    boardParams: initParams(),
    metaData: null,
  }),
  reducers: {
    setBoardParams: (state, action) => {
      state.boardsLoaded = false;
      state.boardParams = {
        ...state.boardParams,
        ...action.payload,
        pageNumber: 1,
      };
    },
    setMetaData: (state, action) => {
      state.metaData = action.payload;
    },
    setBoard: (state, action) => {
      boardAdapter.upsertOne(state, action.payload);
      state.boardsLoaded = false;
    },
  },
  extraReducers: (builder) => {
    builder.addCase(fetchBoardsAsync.pending, (state) => {
      state.status = 'pendingBoardRequests';
    });
    builder.addCase(fetchBoardsAsync.fulfilled, (state, action) => {
      boardAdapter.setAll(state, action.payload);
      (state.status = 'idle'), (state.boardsLoaded = true);
    });
    builder.addCase(fetchBoardsAsync.rejected, (state, action) => {
      console.log(action.payload);
      state.status = 'idle';
    });
  },
});

export const { setBoardParams, setMetaData } = boardSlice.actions;
export const boardSelectors = boardAdapter.getSelectors(
  (state: RootState) => state.board
);
