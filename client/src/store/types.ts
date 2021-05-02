export interface IUser {
  id: string;
  name: string;
}

export interface IRoom {
  id: string;
  name: string;
  cards: Array<string>;
  selectedCard: string | null;
  ownerId: string;
  usersId: Array<string>;
}

export interface IStory {
  id: string;
  name: string;
  average: number | null;
  votes: { [key: string]: string }; // key - userId, value - vote
}

export interface IRootState {
  rooms: Array<IRoom>;
  stories: Array<IStory>;
  users: Array<IUser>;
  user: IUser | null;
}
