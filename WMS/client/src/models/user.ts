export interface User {
  username?: string;
  email: string;
  token: string;
  roles?: string[];
}

export interface UserFormValues {
  username?: string;
  email: string;
  password: string;
  displayName?: string;
}
