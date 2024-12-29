/* eslint-disable @typescript-eslint/no-unused-expressions */
import {
  createAsyncThunk,
  createEntityAdapter,
  createSlice,
} from '@reduxjs/toolkit';
import agent from '../../api/agent';
import { RootState } from '../../store/configureStore';
import { Request, RequestParams } from '../../models/request';
import { MetaData } from '../../models/pagination';

interface RequestState {
  requestsLoaded: boolean;
  filtersLoaded: boolean;
  status: string;
  approvalStatus: {
    approvalStatusId: number;
    approvalStatusName: string;
  };
  requestType: {
    requestTypeId: number;
    requestTypeName: string;
  };
  requestParams: RequestParams;
  metaData: MetaData | null;
}

const requestAdapter = createEntityAdapter({
  selectId: (e: any) => e.requestId,
});

function getAxiosParams(requestParams: RequestParams) {
  const params = new URLSearchParams();
  params.append('pageNumber', requestParams.pageNumber.toString());
  params.append('pageSize', requestParams.pageSize.toString());
  params.append('orderBy', requestParams.orderBy);
  if (requestParams.searchTerm)
    params.append('searchTerm', requestParams.searchTerm);
  if (requestParams.approvalStatus.approvalStatusName.length > 0)
    params.append('approvalStatus', requestParams.approvalStatus.toString());
  if (requestParams.requestType.requestTypeName.length > 0)
    params.append('types', requestParams.requestType.toString());
  return params;
}

// ? Fetch all requests
export const fetchRequestsAsync = createAsyncThunk<
  Request[],
  void,
  { state: RootState }
>('request/fetchRequestsAsync', async (_, thunkAPI) => {
  const params = getAxiosParams(thunkAPI.getState().request.requestParams);
  try {
    const response = await agent.UserRequest.list(params);
    thunkAPI.dispatch(setMetaData(response.MetaData));
    return response.items;
  } catch (error: any) {
    return thunkAPI.rejectWithValue({ error: error.data });
  }
});

// ? Fetch a single request
export const fetchRequestAsync = createAsyncThunk<Request, number>(
  'request/fetchRequestAsync',
  async (requestId, thunkAPI) => {
    try {
      const request = await agent.UserRequest.details(requestId);
      return request;
    } catch (error: any) {
      return thunkAPI.rejectWithValue({ error: error.message });
    }
  }
);

// ? Fetch requests based on a filter
export const fetchFilters = createAsyncThunk(
  'request/fetchFilters',
  async (_, thunkAPI) => {
    try {
      return agent.UserRequest.fetchFilters();
    } catch (error: any) {
      return thunkAPI.rejectWithValue({ error: error.message });
    }
  }
);

// ? Fetch request types for select control
export const fetchTypes = createAsyncThunk(
  'request/types',
  async (_, thunkAPI) => {
    try {
      return agent.Type.fetchTypes();
    } catch (error: any) {
      return thunkAPI.rejectWithValue({ error: error.message });
    }
  }
);

// ? Approve or deny a request
export const addApprovalStatus = createAsyncThunk<
  Request,
  { requestId: string; approvalStatusName?: string }
>('request/approve', async (approvalStatus, thunkAPI) => {
  try {
    return agent.UserRequest.approve(approvalStatus);
  } catch (error: any) {
    return thunkAPI.rejectWithValue({ error: error.message });
  }
});

// ? Set the request type
export const setRequestType = createAsyncThunk<
  Request,
  { requestId: string; requestTypeName?: string }
>('request/set-type', async (requestType, thunkAPI) => {
  try {
    return agent.UserRequest.setType(requestType);
  } catch (error: any) {
    return thunkAPI.rejectWithValue({ error: error.message });
  }
});

function initParams(): RequestParams {
  return {
    pageNumber: 1,
    pageSize: 9,
    orderBy: 'title',
    approvalStatus: {
      approvalStatusId: 0,
      approvalStatusName: '',
    },
    requestType: {
      requestTypeId: 0,
      requestTypeName: '',
    },
  };
}

export const requestSlice = createSlice({
  name: 'request',
  initialState: requestAdapter.getInitialState<RequestState>({
    requestsLoaded: false,
    filtersLoaded: false,
    status: 'idle',
    approvalStatus: {
      approvalStatusId: 0,
      approvalStatusName: '',
    },
    requestType: {
      requestTypeId: 0,
      requestTypeName: '',
    },
    requestParams: initParams(),
    metaData: null,
  }),
  reducers: {
    setRequestParams: (state, action) => {
      state.requestsLoaded = false;
      state.requestParams = {
        ...state.requestParams,
        ...action.payload,
        pageNumber: 1,
      };
    },
    setPageNumber: (state, action) => {
      state.requestsLoaded = false;
      state.requestParams = { ...state.requestParams, ...action.payload };
    },
    setMetaData: (state, action) => {
      state.metaData = action.payload;
    },
    resetRequestParams: (state) => {
      state.requestParams = initParams();
    },
    setRequest: (state, action) => {
      requestAdapter.upsertOne(state, action.payload);
      state.requestsLoaded = false;
    },
    removeRequest: (state, action) => {
      requestAdapter.removeOne(state, action.payload);
      state.requestsLoaded = false;
    },
  },
  extraReducers: (builder) => {
    // ? All Requests
    builder.addCase(fetchRequestsAsync.pending, (state) => {
      state.status = 'pendingFetchRequests';
    });
    builder.addCase(fetchRequestsAsync.fulfilled, (state, action) => {
      requestAdapter.setAll(state, action.payload);
      (state.status = 'idle'), (state.requestsLoaded = true);
    });
    builder.addCase(fetchRequestsAsync.rejected, (state, action) => {
      console.log(action.payload);
      state.status = 'idle';
    });
    // ? Single Request
    builder.addCase(fetchRequestAsync.pending, (state) => {
      state.status = 'pendingFetchRequest';
    });
    builder.addCase(fetchRequestAsync.fulfilled, (state, action) => {
      requestAdapter.upsertOne(state, action.payload);
      state.status = 'idle';
    });
    builder.addCase(fetchRequestAsync.rejected, (state, action) => {
      console.log(action);
      state.status = 'idle';
    });
    // ? Filters
    builder.addCase(fetchFilters.pending, (state) => {
      state.status = 'pendingFetchFilters';
    });
    builder.addCase(fetchFilters.fulfilled, (state, action) => {
      state.approvalStatus = action.payload.approvalStatus.approvalStatusName;
      state.requestType = action.payload.requestType;
      state.status = action.payload.statusName;
      state.status = 'idle';
      state.filtersLoaded = true;
    });
    builder.addCase(fetchFilters.rejected, (state) => {
      state.status = 'idle';
    });
    // ? Request Types
    builder.addCase(fetchTypes.pending, (state) => {
      state.status = 'pendingFetchTypes';
    });
    builder.addCase(fetchTypes.fulfilled, (state, action) => {
      state.requestType = action.payload.types;
      state.status = 'idle';
    });
    builder.addCase(fetchTypes.rejected, (state) => {
      state.status = 'idle';
    });
    // ? Approve Request
    builder.addCase(addApprovalStatus.pending, (state) => {
      state.status = 'pendingApprove';
    });
    builder.addCase(addApprovalStatus.fulfilled, (state, action) => {
      state.approvalStatus = action.payload.approvalStatus;
      state.requestsLoaded = true;
      state.status = 'idle';
    });
    builder.addCase(addApprovalStatus.rejected, (state) => {
      state.status = 'idle';
    });
    // ? Set Request Type
    builder.addCase(setRequestType.pending, (state) => {
      state.status = 'pendingSetType';
    });
    builder.addCase(setRequestType.fulfilled, (state, action) => {
      state.requestType = action.payload.requestType;
      state.requestsLoaded = true;
      state.status = 'idle';
    });
    builder.addCase(setRequestType.rejected, (state) => {
      state.status = 'idle';
    });
  },
});

// TODO - I need to add in more set properties for the requests (reducers)

export const { setRequestParams, setPageNumber, setMetaData } =
  requestSlice.actions;
export const requestSelectors = requestAdapter.getSelectors(
  (state: RootState) => state.request
);
