import * as React from 'react';
import Deck from '../deck/deck';
import {RouteComponentProps} from 'react-router-dom';
import Menu from '../menu/menu';
import {RoutePath} from '../../routes';
import {IRoom, IUser} from '../../store/types';
import BrieflyResults from '../briefly-results/briefly-results';
import History from '../history/history';
import {mockState} from '../../mock/mock';
import './main-page.css';

export interface IMainPageProps extends RouteComponentProps {
  room: IRoom;
  user: IUser;
  onShowModal(): void;
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
    if (this.props.room === undefined) {
      this.props.history.push('/error-nonexistent-room');
      return null;
    } else {
      return <main className="room">
        <h2 className="room-name">{this.props.room.name}</h2>
        <div className="room-content">
          <div className="results">
            {this.state.isPlanning ?
              <Deck/> :
              <BrieflyResults/>}
            <History stories={mockState.stories} onShowModal={this.props.onShowModal}/>
          </div>
          <Menu
            addEnter={!this.state.isPlanning}
            onClick={this.handleClick}
          />
        </div>
      </main>;
    }
  }

  componentDidMount() {
    this.props.user === null && this.props.room && this.props.history.push(`${RoutePath.INVITE}/${this.props.room.id}`);
  }
}

export default MainPageView;
