import React, { useState } from "react";
import './Setting.css';

const Setting = () => {
     const [activeTab, setActiveTab] = useState('Account');

     const renderContent = () => {
          switch (activeTab) {
               case 'Account':
                    return (
                         <div>
                              <h2>Your Cursus Account</h2>
                              <p>This is your public presence on Cursus. You need a account to upload your paid courses, comment on courses, purchased by students, or earning.</p>
                         </div>
                    );
               case 'Notification':
                    return <div>Notification Settings</div>;
               case 'Privacy':
                    return <div>Privacy Settings</div>;
               case 'Billing and Payouts':
                    return <div>Billing and Payouts Settings</div>;
               case 'API Clients':
                    return <div>API Clients Settings</div>;
               case 'Close Account':
                    return <div>Close Account Settings</div>;
               default:
                    return null;
          }
     };

     return (
          <div className="settings-page">
               <h1>⚙️ Setting</h1>
               <div className="tabs">
                    {['Account', 'Notification', 'Privacy', 'Billing and Payouts', 'API Clients', 'Close Account'].map(tab => (
                         <button
                              key={tab}
                              className={activeTab === tab ? 'active' : ''}
                              onClick={() => setActiveTab(tab)}
                         >
                              {tab}
                         </button>
                    ))}
               </div>
               <div className="tab-content">
                    {renderContent()}
               </div>
          </div>
     );
};

export default Setting;
