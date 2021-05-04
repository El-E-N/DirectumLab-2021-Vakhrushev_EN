import {IRootState} from '../../store/types';
import {compose} from 'redux';
import * as React from 'react';
import {withRouter} from 'react-router-dom';
import {connect} from 'react-redux';
import MainPageView, {IMainPageProps} from './main-page-view';
import {roomByIdSelector} from '../../store/room/room-selectors';

interface IMain {
  onShowModal(): void;
}

const mapStateToProps = (state: IRootState, ownProps: IMainPageProps) => {
  const room = roomByIdSelector(state, ownProps.match.params.id);
  return {
    room,
    user: state.user,
    stories: state.stories,
  };
};

export default compose<React.ComponentClass<IMain>>(withRouter, connect(mapStateToProps))(MainPageView);
