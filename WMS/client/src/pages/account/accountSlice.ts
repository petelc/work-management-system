/* eslint-disable @typescript-eslint/no-unused-expressions */
import {
  createAsyncThunk,
  createEntityAdapter,
  createSlice,
  isAnyOf,
} from '@reduxjs/toolkit';
import { FieldValues } from 'react-hook-form';
import { toast } from 'react-toastify';

import agent from '../../api/agent';
import { router } from '../../helpers/router/Routes';
import { User } from '../../models/user';
import { RootState } from '../../store/configureStore';

interface AccountState {
  usersLoaded: boolean;
  user: User | null;
  users: string[];
  status: string;
}

// const initialState: AccountState = {
//   usersLoaded: false,
//   user: null,
//   users: [],
// };

const accountAdapter = createEntityAdapter({
  selectId: (e: any) => e.id,
});

export const signInUser = createAsyncThunk<User, FieldValues>(
  'account/signInUser',
  async (data, thunkAPI) => {
    try {
      const userDto = await agent.Account.login(data);

      const { ...user } = userDto;

      localStorage.setItem('user', JSON.stringify(user));
      return user;
    } catch (error: any) {
      return thunkAPI.rejectWithValue({ error: error.message });
    }
  }
);

export const fetchCurrentUser = createAsyncThunk<User>(
  'account/fetchCurrentUser',
  async (_, thunkAPI) => {
    thunkAPI.dispatch(setUser(JSON.parse(localStorage.getItem('user')!)));
    try {
      const userDto = await agent.Account.currentUser();
      const { ...user } = userDto;
      localStorage.setItem('user', JSON.stringify(user));
      return user;
    } catch (error: any) {
      return thunkAPI.rejectWithValue({ error: error.data });
    }
  },
  {
    condition: () => {
      if (!localStorage.getItem('user')) return false;
    },
  }
);

export const fetchAllUsers = createAsyncThunk(
  'account/fetchAllUsers',
  async (_, thunkAPI) => {
    try {
      const users = agent.Requestor.allUsers();
      return users;
    } catch (error: any) {
      return thunkAPI.rejectWithValue({ error: error.data });
    }
  }
);

export const accountSlice = createSlice({
  name: 'account',
  initialState: accountAdapter.getInitialState<AccountState>({
    usersLoaded: false,
    user: null,
    users: [],
    status: 'idle',
  }),
  reducers: {
    signOut: (state) => {
      state.user = null;
      localStorage.removeItem('user');
      router.navigate('/login');
    },
    setUser: (state, action) => {
      const claims = JSON.parse(atob(action.payload.token.split('.')[1]));
      const roles =
        claims['http://schema.microsoft.com/ws/2008/06/identity/claims/role'];
      state.user = {
        ...action.payload,
        roles: typeof roles === 'string' ? [roles] : roles,
      };
    },
  },
  extraReducers: (builder) => {
    builder.addCase(fetchCurrentUser.rejected, (state) => {
      state.user = null;
      localStorage.removeItem('user');
      toast.error('Session expired - please login again');
      router.navigate('/');
    });
    builder.addCase(fetchAllUsers.pending, (state) => {
      state.status = 'pendingFetchAllUsers';
    });
    builder.addCase(fetchAllUsers.fulfilled, (state, action) => {
      state.users = action.payload.users;
      (state.status = 'idle'), (state.usersLoaded = true);
    });
    builder.addCase(fetchAllUsers.rejected, (state, action) => {
      console.log(action.payload);
      state.status = 'idle';
    });
    builder.addMatcher(
      isAnyOf(signInUser.fulfilled, fetchCurrentUser.fulfilled),
      (state, action) => {
        const claims = JSON.parse(atob(action.payload.token.split('.')[1]));
        const roles =
          claims['http://schema.microsoft.com/ws/2008/06/identity/claims/role'];
        state.user = {
          ...action.payload,
          roles: typeof roles === 'string' ? [roles] : roles,
        };
      }
    );
  },
});

export const { signOut, setUser } = accountSlice.actions;

export const accountSelectors = accountAdapter.getSelectors(
  (state: RootState) => state.account
);
