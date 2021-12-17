using Application.Inventory.Queries.Dtos;
using Application.Inventory.Queries.Query;
using Application.Inventory.WriteModel.Commands;
using AutoMapper;
using CQRSlite.Commands;
using CQRSlite.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StockAPI.Controllers.CQRS
{
    [Route("api/cqrs/[controller]")]
    [ApiController]
    public class CQRSDevelopmentController : ControllerBase
    {
        private readonly ICommandSender _commandSender;
        private readonly IQueryProcessor _queryProcessor;
        private readonly IMapper _mapper;

        //  TODO Change HTTP GET/POST to PUT/DELETE etc...
        public CQRSDevelopmentController(IMapper mapper, ICommandSender commandSender, IQueryProcessor queryProcessor)
        {
            _mapper = mapper;
            _commandSender = commandSender;
            _queryProcessor = queryProcessor;
        }

        /// <summary>
        ///     Add new Inventory Item 
        ///     TODO: Avoid using DTO which is a data transfer object and possibly using the domain model maybe
        ///         or an independent View Model.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<InventoryItemDto>> Add(InventoryItemDto item, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateInventoryItemCommand>(item);
            await _commandSender.Send(command, cancellationToken);
            //  Get The Newly submitted Object
            return CreatedAtAction(nameof(Get), new { id = item.id });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            
            await _queryProcessor.Query<InventoryItemDto>(new GetInventoryItem(id));
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> ChangeName(Guid id, int InventoryId, string name, int version, CancellationToken cancellationToken)
        {
            //  TODO: Understand How to handle existing Objects
            await _commandSender.Send(new RenameInventoryItem(Guid.NewGuid(), InventoryId, name, version), cancellationToken);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Deactivate(Guid id, int InventoryItemId, int version, CancellationToken cancellationToken)
        {
            //  TODO: Build Deactivate Inventory Item
            await _commandSender.Send(new DeactivateInventoryItem(id, InventoryItemId, version), cancellationToken);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> GetList(Guid id)
        {
            //  TODO: Get List Of Items In Inventory
            //ViewData.Model = await _queryProcessor.Query(new GetInventoryItemDetails(id));
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> CheckIn(Guid id, int InventoryItemId, int version, CancellationToken cancellationToken)
        {
            //  TODO: Don't know what use this is
            await _commandSender.Send(new CheckInItemsToInventory(id, InventoryItemId, version), cancellationToken);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> DeactivateInventoryItem(Guid id, int InventoryItemId, CancellationToken cancellationToken)
        {
            await _commandSender.Send(new RemoveItemFromInventory(id, InventoryItemId), cancellationToken);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> RemoveStock(Guid id, int InventoryId, int number, CancellationToken cancellationToken)
        {
            await _commandSender.Send(new RemoveItemsFromStock(id, InventoryId, number), cancellationToken);
            return RedirectToAction("Index");
        }
    }
}
