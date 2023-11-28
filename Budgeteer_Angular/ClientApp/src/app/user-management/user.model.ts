export interface User {
  emailAddress: string;
  firstName: string;
  lastName: string;
}

export class User implements User{
  constructor(
    public emailAddress: string = '',
    public firstName: string = '',
    public lastName: string = ''
  ) { }
}
