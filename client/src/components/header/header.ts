import {IRootState} from '../../store/types';
import {userSelector} from '../../store/user/user-selectors';
import {connect} from 'react-redux';
import HeaderView from './header-view';
import {compose} from 'redux';
import * as React from 'react';
import {withRouter} from 'react-router-dom';

const mapStateToProps = (state: IRootState) => {
  return {
    user: userSelector(state),
  };
};

export default compose<React.ComponentClass>(withRouter, connect(mapStateToProps))(HeaderView);
