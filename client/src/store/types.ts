export interface IPlayer {
  id: string;
  name: string;
}

export interface IRoom {
  id: string;
  hash: string;
  name: string;
  cards: Array<ICard>;
  hostId: string;
  creatorId: string;
  players: Array<IPlayer>;
  currentDiscussionId: string | null;
  choosedDiscussionId: string | null;
  shownModal: boolean;
}

export interface IDiscussion {
  id: string;
  name: string | null;
  average: number | null;
  players: Array<IPlayer> | null;
  voteArray: { [key: string]: IVote | null }; // key - userId, value - vote
}

export interface IVote {
  id: string;
  card: ICard | null;
}

export interface ICard {
  id: string;
  value: string;
}

export interface IRootState {
  room: IRoom | null;
  discussions: Array<IDiscussion> | null;
  user: IPlayer | null;
}
