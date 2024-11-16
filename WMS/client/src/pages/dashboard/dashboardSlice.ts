import {
  createAsyncThunk,
  createEntityAdapter,
  createSlice,
} from '@reduxjs/toolkit';
import agent from '../../api/agent';
import { RootState } from '../../store/configureStore';
import { RequestCount } from '../../models/requestCounts';

interface DashboardState {
  requestCounts: RequestCount;
  countsLoaded: boolean;
  status: string;
}

const dashboardAdapter = createEntityAdapter({
  selectId: (e: any) => e.id,
});

export const fetchRequestCountsAsync = createAsyncThunk<
  RequestCount[],
  void,
  { state: RootState }
>('dashboard/req_count', async (_, thunkAPI) => {
  try {
    const response = await agent.RequestCounts.list();
    console.log(response);
    return response;
  } catch (error: any) {
    return thunkAPI.rejectWithValue({ error: error.message });
  }
});

export const dashboardSlice = createSlice({
  name: 'dashboard',
  initialState: dashboardAdapter.getInitialState<DashboardState>({
    requestCounts: {
      id: 0,
      title: '',
      value: 0,
      valueMax: 0,
      startAngle: 0,
      endAngle: 0,
    },
    countsLoaded: false,
    status: 'idle',
  }),
  reducers: {
    setRequestCount: (state, action) => {
      dashboardAdapter.upsertOne(state, action.payload);
      state.countsLoaded = false;
    },
  },
  extraReducers: (builder) => {
    builder.addCase(fetchRequestCountsAsync.pending, (state) => {
      state.status = 'pendingFetchRequestCounts';
    });
    builder.addCase(fetchRequestCountsAsync.fulfilled, (state, action) => {
      dashboardAdapter.setAll(state, action.payload);
      state.countsLoaded = true;
      state.status = 'idle';
    });
    builder.addCase(fetchRequestCountsAsync.rejected, (state, action) => {
      console.log(action.payload);
      state.status = 'idle';
    });
  },
});

export const { setRequestCount } = dashboardSlice.actions;

export const dashboardSelectors = dashboardAdapter.getSelectors(
  (state: RootState) => state.dashboard
);
