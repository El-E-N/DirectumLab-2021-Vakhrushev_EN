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
  users: Array<IUser>;
  storiesId: Array<string>;
}

export interface IStory {
  id: string;
  name: string | null;
  average: number | null;
  votes: { [key: string]: string }; // key - userId, value - vote
}

export interface IRootState {
  rooms: Array<IRoom>;
  stories: Array<IStory>;
  user: IUser | null;
}
