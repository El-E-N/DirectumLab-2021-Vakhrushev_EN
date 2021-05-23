import * as React from 'react';
import Deck from '../deck/deck';
import {RouteComponentProps} from 'react-router-dom';
import Menu from '../menu/menu';
import {RoutePath} from '../../routes';
import {IRoom, IPlayer, IVote, IDiscussion} from '../../store/types';
import BrieflyResults from '../briefly-results/briefly-results';
import History from '../history/history';
import './main-page.css';

interface IMatchParams {
  hash: string;
}

export interface IMainPageProps extends RouteComponentProps<IMatchParams> {
  room: IRoom | null;
  player: IPlayer | null;
  vote: IVote;
  discussions: Array<IDiscussion> | null;
  voteArray: Array<IVote> | null;
  getRoom(hash: string): IRoom;
  updateVote(voteId: string, cardId: string): void;
  getVote(user: IPlayer): IVote | null;
  loadingDiscussions(roomId: string): void;
  createVote(roomId: string, playerId: string, discussionId: string): void;
  changeShownModal(activated: boolean): void;
}

interface IState {
  isPlanning: boolean;
}

export class MainPageView extends React.Component<IMainPageProps, IState> {
  constructor(props: IMainPageProps) {
    super(props);
    this.state = {
      isPlanning: true,
    };
    this.handleClick = this.handleClick.bind(this);
  }

  public handleClick() {
    this.setState({
      isPlanning: false,
    });
  }

  public render() {
    return this.props.room === null ?
      null :
      <main className="room">
        <h2 className="room-name">{this.props.room && this.props.room.name}</h2>
        <div className="room-content">
          <div className="results">
            {this.state.isPlanning ?
              <Deck
                room={this.props.room}
                updateVote={this.props.updateVote}
                vote={this.props.vote}
              /> :
              this.props.voteArray && <BrieflyResults room={this.props.room} voteArray={this.props.voteArray}/>}
            {this.props.discussions &&
            <History discussions={this.props.discussions} changeShownModal={this.props.changeShownModal}/>}
          </div>

          <Menu
            addEnter={!this.state.isPlanning}
            onClick={this.handleClick}
            room={this.props.room}
            player={this.props.player}
            getVote={this.props.getVote}
          />
        </div>
      </main>;
  }

  async componentDidMount() {
    this.props.room === null && await this.props.getRoom(this.props.match.params.hash);

    if (this.props.player === null) {
      this.props.history.push(`${RoutePath.INVITE}/${this.props.match.params.hash}`);
    } else {
      this.props.room && await this.props.loadingDiscussions(this.props.room.id);

      await setInterval(() => {
        this.props.getRoom(this.props.match.params.hash);
        this.props.room && this.props.loadingDiscussions(this.props.room.id);
      }, 5000);

      const currentDiscussion = this.props.discussions && this.props.discussions[this.props.discussions.length - 1];
      console.log(this.props.discussions, currentDiscussion);
      this.props.room && this.props.player && currentDiscussion &&
      await this.props.createVote(this.props.room.id, this.props.player.id, currentDiscussion.id);
    }
  }
}

export default MainPageView;
