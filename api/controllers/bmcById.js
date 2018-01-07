'use strict';
/*
 'use strict' is not required but helpful for turning syntactical errors into true errors in the program flow
 https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Strict_mode
*/

/*
 Modules make it possible to import JavaScript files into your application.  Modules are imported
 using 'require' statements that give you a reference to the module.

  It is a good idea to list the modules that your application depends on in the package.json in the project root
 */
var util = require('util');

/*
 Once you 'require' a module you can reference the things that it exports.  These are defined in module.exports.

 For a controller in a127 (which this is) you should export the functions referenced in your Swagger document by name.

 Either:
  - The HTTP Verb of the corresponding operation (get, put, post, delete, etc)
  - Or the operationId associated with the operation in your Swagger document

  In the starter/skeleton project the 'get' operation on the '/hello' path has an operationId named 'hello'.  Here,
  we specify that in the exports of this module that 'hello' maps to the function named 'hello'
 */
module.exports = {
  bmcById: bmcById
};

/*
  Functions in a127 controllers used for operations should take two parameters:

  Param 1: a handle to the request object
  Param 2: a handle to the response object
 */
function bmcById(req, res) {
  // variables defined in the Swagger document can be referenced using req.swagger.params.{parameter_name}
  var canvasData = {
    designedFor: "",
    keyResources: [],
    channels: [],
    costStructure: [],
    customerRelationships: [],
    customerSegments:	[],
    keyActivities: [],
    keyPartners: [],
    revenueStreams: [],
    valuePropositions: [] 
  };

  var entities = [
      {title: 'a', description: 'abc', order: 4, created: '2018-01-06 10:14'}
    , {title: 'b', description: 'abc', order: 3, created: '2018-01-05 11:24'}
    , {title: 'c', description: 'abc', order: 5, created: '2018-01-02 14:34'}
    , {title: 'd', description: 'abc', order: 1, created: '2018-01-03 05:44'}
    , {title: 'e', description: 'abc', order: 2, created: '2018-01-04 23:54'}
    , {title: 'f', description: 'abc', order: 6, created: '2018-01-01 09:04'}
  ];

  canvasData.designedFor = 'Kalle Kula AB';
  canvasData.id = 1;
  canvasData.name = 'Test Canvas';

  canvasData.channels = [];
  canvasData.channels.push(entities[0]);
  canvasData.channels.push(entities[1]);

  canvasData.costStructure = [];
  canvasData.costStructure.push(entities[0]);
  canvasData.costStructure.push(entities[1]);
  canvasData.costStructure.push(entities[2]);

  canvasData.customerRelationships = [];
  canvasData.customerRelationships.push(entities[0]);
  canvasData.customerRelationships.push(entities[1]);
  canvasData.customerRelationships.push(entities[2]);
  canvasData.customerRelationships.push(entities[3]);
  canvasData.customerRelationships.push(entities[4]);

  canvasData.customerSegments = [];
  canvasData.customerSegments.push(entities[0]);
  canvasData.customerSegments.push(entities[1]);
  canvasData.customerSegments.push(entities[2]);
  canvasData.customerSegments.push(entities[3]);
  canvasData.customerSegments.push(entities[4]);
  canvasData.customerSegments.push(entities[5]);

  canvasData.keyActivities = [];
  canvasData.keyActivities.push(entities[0]);
  canvasData.keyActivities.push(entities[1]);
  canvasData.keyActivities.push(entities[2]);

  canvasData.keyPartners = [];
  canvasData.keyPartners.push(entities[0]);
  canvasData.keyPartners.push(entities[1]);
  canvasData.keyPartners.push(entities[2]);
  canvasData.keyPartners.push(entities[3]);

  canvasData.keyResources = [];
  canvasData.keyResources.push(entities[0]);
  canvasData.keyResources.push(entities[1]);
  canvasData.keyResources.push(entities[2]);
  canvasData.keyResources.push(entities[3]);
  canvasData.keyResources.push(entities[4]);
  canvasData.keyResources.push(entities[5]);

  canvasData.revenueStreams = [];
  canvasData.revenueStreams.push(entities[0]);

  canvasData.valuePropositions = [];
  canvasData.valuePropositions.push(entities[0]);
  canvasData.valuePropositions.push(entities[1]);

  // this sends back a JSON response which is a single string
  res.json(canvasData);
}
